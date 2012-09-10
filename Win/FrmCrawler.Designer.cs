namespace Win
{
    partial class FrmCrawler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(61, 22);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(357, 21);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://www.lvmama.com/dest/zhongguo_zhejiang/ticket_tab_5_2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "GO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "网址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "正则:";
            // 
            // txtRegex
            // 
            this.txtRegex.Location = new System.Drawing.Point(61, 59);
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.Size = new System.Drawing.Size(357, 21);
            this.txtRegex.TabIndex = 3;
            this.txtRegex.Text = "/dest/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "路径:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(61, 99);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(357, 21);
            this.txtPath.TabIndex = 5;
            // 
            // FrmCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 183);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtUrl);
            this.Name = "FrmCrawler";
            this.Text = "FrmCrawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPath;
    }
}