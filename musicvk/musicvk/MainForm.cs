/*
 * Created by SharpDevelop.
 * User: Никитка
 * Date: 30.07.2016
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace musicvk
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public int AudioCount =0;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
				
		
		void TextBox2Click(object sender, EventArgs e)
		{
			folderBrowserDialog1 = new FolderBrowserDialog();
			folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
			folderBrowserDialog1.ShowDialog();
			PathBox.Text = folderBrowserDialog1.SelectedPath;
		}
		
		void GetTokenButtonClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://oauth.vk.com/authorize?client_id=5568434&redirect_uri=https://oauth.vk.com/blank.html&scope=audio&response_type=token&v=5.53");
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			string Token = TokenBox.Text.Substring(45,85);
			//Лютый пиздец отсюда
			string UID = TokenBox.Text.Substring(156);
			string SongFolder = PathBox.Text;
			string deb = GET("https://api.vk.com/method/audio.get","owner_id="+UID+"&access_token="+Token+"&v=5.53");
			Dictionary<string,Dictionary<string,object>> JSON = JsonConvert.DeserializeObject<Dictionary<string,Dictionary<string,object>>>(GET("https://api.vk.com/method/audio.get","owner_id="+UID+"&access_token="+Token+"&v=5.53"));
			//И досюда. Не лезть!
			AudioCount = Convert.ToInt32(JSON["response"]["count"]);
			List<Dictionary<string,string>> Songs = Songlist(((JArray)(JSON["response"]["items"])).ToObject<Dictionary<string,string>[]>());
			progressBar1.Minimum=0;
			progressBar1.Maximum=AudioCount;
			progressBar1.Value =0;
			progressBar1.Step = 1;
			
			
			Thread thread = new Thread(() =>DoWork(progressBar1,AudioCount,Songs,SongFolder));
			thread.Start();
		}
			
		
		public List<Dictionary<string,string>> Songlist (Dictionary<string,string>[] json)
		{
			List<Dictionary<string,string>> response = new List<Dictionary<string,string>>();
			foreach (Dictionary<string,string> song in json)
			{
				Dictionary<string,string> addon = new Dictionary<string, string>();
				addon.Add ("name",song["artist"]+" — "+song["title"]);
				addon.Add ("url",song["url"]);
				response.Add(addon);
			}
			return response;
		}
		private static string GET(string Url, string Data)
		{
			System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?" + Data);
			System.Net.WebResponse resp = req.GetResponse();
			System.IO.Stream stream = resp.GetResponseStream();
			System.IO.StreamReader sr = new System.IO.StreamReader(stream);
			string Out = sr.ReadToEnd();
			sr.Close();
			return Out;
		}
		
		
		public void DoWork(ProgressBar progressBar1, int AudioCount, List<Dictionary<string,string>> Songs, string SongFolder)
    {
        while (!_shouldStop)
        {
            
			int i = 1;
			foreach (Dictionary<string,string> Song in Songs)
			{
				
				using (var client = new WebClient())
					{
					try
					{
					client.DownloadFile(Song["url"], SongFolder+"/"+Song["name"]+".mp3");
					}
					catch (WebException e )
					{
						if (e.Status == WebExceptionStatus.Timeout)
						{
							Console.WriteLine(e.Status.ToString());
							for (int a = 0; a<=5;a++)
							{
								client.DownloadFile(Song["url"], SongFolder+"/"+Song["name"]+".mp3");
							}
						}
					}
					}
				Invoke((MethodInvoker)delegate
    	  		          {
                                progressLabel.Text = i+"/"+AudioCount;
								i++;
								progressBar1.PerformStep();
				       });
				Thread.Sleep(1);
				if (i==AudioCount)
				{
					_shouldStop=true;
				}
				
        }
    }
        return;
    }
		
		    public void RequestStop()
    {
        _shouldStop = true;
    }
    // Volatile is used as hint to the compiler that this data
    // member will be accessed by multiple threads.
    private volatile bool _shouldStop;
		

	
    
}
	
}