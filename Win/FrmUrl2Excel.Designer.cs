namespace Win
{
    partial class FrmUrl2Excel
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
            this.rtbUrllist = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.btnRule = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // rtbUrllist
            // 
            this.rtbUrllist.Location = new System.Drawing.Point(12, 48);
            this.rtbUrllist.Name = "rtbUrllist";
            this.rtbUrllist.Size = new System.Drawing.Size(731, 131);
            this.rtbUrllist.TabIndex = 0;
            this.rtbUrllist.Text = "http://www.17u.cn/scenery/BookSceneryTicket_2851.html\nhttp://www.17u.cn/scenery/B" +
                "ookSceneryTicket_20730.html\nhttp://www.17u.cn/scenery/BookSceneryTicket_6270.htm" +
                "l";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入需要解析的URL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "输出路径:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "D:\\";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 272);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(636, 21);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.Text = "e:\\";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(668, 333);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "转化";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "规则路径:";
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(12, 207);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(636, 21);
            this.txtRule.TabIndex = 7;
            this.txtRule.Text = "D:\\tongcheng.xml";
            // 
            // btnRule
            // 
            this.btnRule.Location = new System.Drawing.Point(668, 205);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(75, 23);
            this.btnRule.TabIndex = 8;
            this.btnRule.Text = "选择";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(668, 270);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 9;
            this.btnOutput.Text = "选择";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.SelectedPath = "D:\\";
            // 
            // FrmUrl2Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 368);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnRule);
            this.Controls.Add(this.txtRule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbUrllist);
            this.Name = "FrmUrl2Excel";
            this.Text = "FrmUrl2Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbUrllist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
    }
}