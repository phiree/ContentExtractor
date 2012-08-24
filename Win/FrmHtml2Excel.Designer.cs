namespace Win
{
    partial class FrmHtml2Excel
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
            this.btnRule = new System.Windows.Forms.Button();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnHtml = new System.Windows.Forms.Button();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(676, 168);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 18;
            this.btnOutput.Text = "选择";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnRule
            // 
            this.btnRule.Location = new System.Drawing.Point(676, 103);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(75, 23);
            this.btnRule.TabIndex = 17;
            this.btnRule.Text = "选择";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(20, 105);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(636, 21);
            this.txtRule.TabIndex = 16;
            this.txtRule.Text = "D:\\yiqiu.xml";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "规则路径:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(676, 222);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 14;
            this.btnConvert.Text = "转化";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // folderBrowserDialog2
            // 
            this.folderBrowserDialog2.SelectedPath = "D:\\";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(20, 170);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(636, 21);
            this.txtOutput.TabIndex = 13;
            this.txtOutput.Text = "e:\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "输出路径:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Html路径:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "D:\\";
            // 
            // btnHtml
            // 
            this.btnHtml.Location = new System.Drawing.Point(676, 46);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(75, 23);
            this.btnHtml.TabIndex = 20;
            this.btnHtml.Text = "选择";
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(20, 48);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(636, 21);
            this.txtHtml.TabIndex = 19;
            this.txtHtml.Text = "D:\\downloading";
            // 
            // FrmHtml2Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 264);
            this.Controls.Add(this.btnHtml);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnRule);
            this.Controls.Add(this.txtRule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmHtml2Excel";
            this.Text = "FrmHtml2Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.TextBox txtHtml;
    }
}