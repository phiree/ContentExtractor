namespace Win
{
    partial class FrmHtml2DB
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
            this.btnHtml = new System.Windows.Forms.Button();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.btnRule = new System.Windows.Forms.Button();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHtml
            // 
            this.btnHtml.Location = new System.Drawing.Point(677, 45);
            this.btnHtml.Name = "btnHtml";
            this.btnHtml.Size = new System.Drawing.Size(75, 23);
            this.btnHtml.TabIndex = 33;
            this.btnHtml.Text = "选择";
            this.btnHtml.UseVisualStyleBackColor = true;
            this.btnHtml.Click += new System.EventHandler(this.btnHtml_Click);
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(21, 47);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(636, 21);
            this.txtHtml.TabIndex = 32;
            this.txtHtml.Text = "D:\\downloading";
            // 
            // btnRule
            // 
            this.btnRule.Location = new System.Drawing.Point(677, 102);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(75, 23);
            this.btnRule.TabIndex = 30;
            this.btnRule.Text = "选择";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(21, 104);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(636, 21);
            this.txtRule.TabIndex = 29;
            this.txtRule.Text = "D:\\yiqiu.xml";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "规则路径:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(677, 160);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 27;
            this.btnConvert.Text = "转化";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 24;
            this.label1.Text = "Html路径:";
            // 
            // FrmHtml2DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 214);
            this.Controls.Add(this.btnHtml);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnRule);
            this.Controls.Add(this.txtRule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Name = "FrmHtml2DB";
            this.Text = "FrmHtml2DB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHtml;
        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label1;
    }
}