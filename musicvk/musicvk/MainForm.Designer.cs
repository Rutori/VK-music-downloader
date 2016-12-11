/*
 * Created by SharpDevelop.
 * User: Никитка
 * Date: 30.07.2016
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace musicvk
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.PathBox = new System.Windows.Forms.TextBox();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.progressLabel = new System.Windows.Forms.Label();
			this.TokenBox = new System.Windows.Forms.TextBox();
			this.GetTokenButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(75, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Вставьте токен с доступом к аудио";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(50, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Токен:";
			// 
			// PathBox
			// 
			this.PathBox.Location = new System.Drawing.Point(120, 85);
			this.PathBox.Name = "PathBox";
			this.PathBox.Size = new System.Drawing.Size(106, 20);
			this.PathBox.TabIndex = 6;
			this.PathBox.Click += new System.EventHandler(this.TextBox2Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(25, 213);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(289, 23);
			this.progressBar1.TabIndex = 7;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(75, 133);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 42);
			this.button1.TabIndex = 8;
			this.button1.Text = "Качаем!";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(25, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Куда качаем";
			// 
			// progressLabel
			// 
			this.progressLabel.Location = new System.Drawing.Point(120, 187);
			this.progressLabel.Name = "progressLabel";
			this.progressLabel.Size = new System.Drawing.Size(100, 23);
			this.progressLabel.TabIndex = 10;
			// 
			// TokenBox
			// 
			this.TokenBox.Location = new System.Drawing.Point(120, 49);
			this.TokenBox.Name = "TokenBox";
			this.TokenBox.Size = new System.Drawing.Size(106, 20);
			this.TokenBox.TabIndex = 11;
			// 
			// GetTokenButton
			// 
			this.GetTokenButton.Location = new System.Drawing.Point(200, 133);
			this.GetTokenButton.Name = "GetTokenButton";
			this.GetTokenButton.Size = new System.Drawing.Size(75, 42);
			this.GetTokenButton.TabIndex = 12;
			this.GetTokenButton.Text = "Получить токен";
			this.GetTokenButton.UseVisualStyleBackColor = true;
			this.GetTokenButton.Click += new System.EventHandler(this.GetTokenButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 262);
			this.Controls.Add(this.GetTokenButton);
			this.Controls.Add(this.TokenBox);
			this.Controls.Add(this.progressLabel);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.PathBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "Пакетная скачка музыки из Вконтакте";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button GetTokenButton;
		private System.Windows.Forms.Label progressLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox PathBox;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TokenBox;
	}
}
