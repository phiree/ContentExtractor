namespace Win
{
    partial class FrmExcelCrawler
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
            this.btnRule = new System.Windows.Forms.Button();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRule
            // 
            this.btnRule.Location = new System.Drawing.Point(356, 44);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(75, 23);
            this.btnRule.TabIndex = 30;
            this.btnRule.Text = "选择";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(12, 46);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(321, 21);
            this.txtRule.TabIndex = 29;
            this.txtRule.Text = "D:\\yiqiu.xml";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 28;
            this.label3.Text = "规则路径:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(356, 100);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 31;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // FrmExcelCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 135);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnRule);
            this.Controls.Add(this.txtRule);
            this.Controls.Add(this.label3);
            this.Name = "FrmExcelCrawler";
            this.Text = "FrmExcelCrawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGo;
    }
}