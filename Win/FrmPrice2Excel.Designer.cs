namespace Win
{
    partial class FrmPrice2Excel
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
            this.btnOutput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnHtml = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btnRule = new System.Windows.Forms.Button();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(670, 164);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 28;
            this.btnOutput.Text = "选择";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "输出路径:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 21;
            this.label1.Text = "Html路径:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "D:\\";
            // 
            // btnHtml
            // 
            this.btnHtml.Location = new System.Drawing.Point(670, 42);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(75, 23);
            this.btnHtml.TabIndex = 30;
            this.btnHtml.Text = "选择";
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(14, 166);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(636, 21);
            this.txtOutput.TabIndex = 23;
            this.txtOutput.Text = "e:\\sst2.xls";
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(14, 44);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(636, 21);
            this.txtHtml.TabIndex = 29;
            this.txtHtml.Text = "D:\\downloading";
            // 
            // btnRule
            // 
            this.btnRule.Location = new System.Drawing.Point(670, 99);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(75, 23);
            this.btnRule.TabIndex = 27;
            this.btnRule.Text = "选择";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(14, 101);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(636, 21);
            this.txtRule.TabIndex = 26;
            this.txtRule.Text = "D:\\yiqiu.xml";
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.SelectedPath = "D:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "规则路径:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(670, 222);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 24;
            this.btnConvert.Text = "转化";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // FrmPrice2Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 270);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHtml);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnRule);
            this.Controls.Add(this.txtRule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConvert);
            this.Name = "FrmPrice2Excel";
            this.Text = "FrmPrice2Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
    }
}