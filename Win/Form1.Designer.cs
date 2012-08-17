namespace Win
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImgLoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImgLoc
            // 
            this.btnImgLoc.Location = new System.Drawing.Point(32, 13);
            this.btnImgLoc.Name = "btnImgLoc";
            this.btnImgLoc.Size = new System.Drawing.Size(75, 23);
            this.btnImgLoc.TabIndex = 0;
            this.btnImgLoc.Text = "图片本地化";
            this.btnImgLoc.UseVisualStyleBackColor = true;
            this.btnImgLoc.Click += new System.EventHandler(this.btnImgLoc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 322);
            this.Controls.Add(this.btnImgLoc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImgLoc;
    }
}

