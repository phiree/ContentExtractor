namespace Win
{
    partial class FrmRulenew
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtRegex = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRulename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rtxtEnd = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtBegin = new System.Windows.Forms.RichTextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbtnRegex = new System.Windows.Forms.RadioButton();
            this.rbtnBeginend = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtRegex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtRulename);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.rtxtEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rtxtBegin);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.rbtnRegex);
            this.groupBox2.Controls.Add(this.rbtnBeginend);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 413);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "提取数据方式";
            // 
            // rtxtRegex
            // 
            this.rtxtRegex.Location = new System.Drawing.Point(16, 95);
            this.rtxtRegex.Name = "rtxtRegex";
            this.rtxtRegex.Size = new System.Drawing.Size(311, 281);
            this.rtxtRegex.TabIndex = 16;
            this.rtxtRegex.Text = "";
            this.rtxtRegex.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "正则表达式:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "规则名称:";
            // 
            // txtRulename
            // 
            this.txtRulename.Location = new System.Drawing.Point(79, 384);
            this.txtRulename.Name = "txtRulename";
            this.txtRulename.Size = new System.Drawing.Size(113, 21);
            this.txtRulename.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "标签名称:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 21);
            this.txtName.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(208, 382);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(57, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rtxtEnd
            // 
            this.rtxtEnd.Location = new System.Drawing.Point(16, 255);
            this.rtxtEnd.Name = "rtxtEnd";
            this.rtxtEnd.Size = new System.Drawing.Size(311, 121);
            this.rtxtEnd.TabIndex = 7;
            this.rtxtEnd.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "开始字符串:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "结束字符串:";
            // 
            // rtxtBegin
            // 
            this.rtxtBegin.Location = new System.Drawing.Point(16, 95);
            this.rtxtBegin.Name = "rtxtBegin";
            this.rtxtBegin.Size = new System.Drawing.Size(311, 128);
            this.rtxtBegin.TabIndex = 3;
            this.rtxtBegin.Text = "";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(203, 51);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "标签组合";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rbtnRegex
            // 
            this.rbtnRegex.AutoSize = true;
            this.rbtnRegex.Location = new System.Drawing.Point(106, 51);
            this.rbtnRegex.Name = "rbtnRegex";
            this.rbtnRegex.Size = new System.Drawing.Size(71, 16);
            this.rbtnRegex.TabIndex = 1;
            this.rbtnRegex.TabStop = true;
            this.rbtnRegex.Text = "正则提取";
            this.rbtnRegex.UseVisualStyleBackColor = true;
            this.rbtnRegex.CheckedChanged += new System.EventHandler(this.rbtnRegex_CheckedChanged);
            // 
            // rbtnBeginend
            // 
            this.rbtnBeginend.AutoSize = true;
            this.rbtnBeginend.Location = new System.Drawing.Point(16, 51);
            this.rbtnBeginend.Name = "rbtnBeginend";
            this.rbtnBeginend.Size = new System.Drawing.Size(71, 16);
            this.rbtnBeginend.TabIndex = 0;
            this.rbtnBeginend.TabStop = true;
            this.rbtnBeginend.Text = "前后截取";
            this.rbtnBeginend.UseVisualStyleBackColor = true;
            this.rbtnBeginend.CheckedChanged += new System.EventHandler(this.rbtnBeginend_CheckedChanged);
            // 
            // FrmRulenew
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(368, 438);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmRulenew";
            this.Text = "FrmRulenew";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.RichTextBox rtxtEnd;
        public System.Windows.Forms.RichTextBox rtxtBegin;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtRulename;
        public System.Windows.Forms.RadioButton rbtnRegex;
        public System.Windows.Forms.RadioButton rbtnBeginend;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.RichTextBox rtxtRegex;
    }
}