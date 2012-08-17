namespace Win
{
    partial class FmImageLocalizer
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
            this.btnStart = new System.Windows.Forms.Button();
            this.tbxUrls = new System.Windows.Forms.TextBox();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.tbxDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(260, 142);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbxUrls
            // 
            this.tbxUrls.AcceptsReturn = true;
            this.tbxUrls.AcceptsTab = true;
            this.tbxUrls.Location = new System.Drawing.Point(12, 39);
            this.tbxUrls.Multiline = true;
            this.tbxUrls.Name = "tbxUrls";
            this.tbxUrls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxUrls.Size = new System.Drawing.Size(220, 355);
            this.tbxUrls.TabIndex = 2;
            this.tbxUrls.WordWrap = false;
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(443, 76);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(100, 21);
            this.tbxPath.TabIndex = 3;
            this.tbxPath.Text = "/ScenicImg/";
            // 
            // tbxDir
            // 
            this.tbxDir.Location = new System.Drawing.Point(297, 24);
            this.tbxDir.Name = "tbxDir";
            this.tbxDir.Size = new System.Drawing.Size(201, 21);
            this.tbxDir.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "保存目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "虚拟路径(用于生成新的Img src)";
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(504, 22);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDir.TabIndex = 1;
            this.btnSelectDir.Text = "选择";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(250, 205);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.Size = new System.Drawing.Size(319, 204);
            this.tbxResult.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "执行结果:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "图片url列表";
            // 
            // FmImageLocalizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 421);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDir);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.tbxUrls);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.btnStart);
            this.Name = "FmImageLocalizer";
            this.Text = "ImageLocalizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbxUrls;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.TextBox tbxDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}