namespace Win
{
    partial class FrmDB2Excel
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
            this.btnSce = new System.Windows.Forms.Button();
            this.txtSce = new System.Windows.Forms.TextBox();
            this.btnPrice = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSce
            // 
            this.btnSce.Location = new System.Drawing.Point(668, 44);
            this.btnSce.Name = "btnSce";
            this.btnSce.Size = new System.Drawing.Size(75, 23);
            this.btnSce.TabIndex = 40;
            this.btnSce.Text = "选择";
            this.btnSce.UseVisualStyleBackColor = true;
            this.btnSce.Click += new System.EventHandler(this.btnSce_Click);
            // 
            // txtSce
            // 
            this.txtSce.Location = new System.Drawing.Point(12, 46);
            this.txtSce.Name = "txtSce";
            this.txtSce.Size = new System.Drawing.Size(636, 21);
            this.txtSce.TabIndex = 39;
            this.txtSce.Text = "E:\\";
            // 
            // btnPrice
            // 
            this.btnPrice.Location = new System.Drawing.Point(668, 101);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(75, 23);
            this.btnPrice.TabIndex = 38;
            this.btnPrice.Text = "选择";
            this.btnPrice.UseVisualStyleBackColor = true;
            this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(12, 103);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(636, 21);
            this.txtPrice.TabIndex = 37;
            this.txtPrice.Text = "E:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "票价excel路径:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(668, 159);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 35;
            this.btnConvert.Text = "转化";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 14);
            this.label1.TabIndex = 34;
            this.label1.Text = "景区excel路径:";
            // 
            // FrmDB2Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 203);
            this.Controls.Add(this.btnSce);
            this.Controls.Add(this.txtSce);
            this.Controls.Add(this.btnPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Name = "FrmDB2Excel";
            this.Text = "FrmDB2Excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSce;
        private System.Windows.Forms.TextBox txtSce;
        private System.Windows.Forms.Button btnPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label1;
    }
}