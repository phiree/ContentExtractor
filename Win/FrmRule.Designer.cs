namespace Win
{
    partial class FrmRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRule));
            this.rulelist = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rtxtEnd = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtBegin = new System.Windows.Forms.RichTextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.rbtnRegex = new System.Windows.Forms.RadioButton();
            this.rbtnBeginend = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtRegex = new System.Windows.Forms.RichTextBox();
            this.txtRulename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rulelist
            // 
            this.rulelist.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rulelist.GridLines = true;
            this.rulelist.Location = new System.Drawing.Point(17, 20);
            this.rulelist.MultiSelect = false;
            this.rulelist.Name = "rulelist";
            this.rulelist.Size = new System.Drawing.Size(254, 325);
            this.rulelist.TabIndex = 0;
            this.rulelist.UseCompatibleStateImageBehavior = false;
            this.rulelist.View = System.Windows.Forms.View.List;
            this.rulelist.Click += new System.EventHandler(this.rulelist_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.rulelist);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(22, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 383);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "页面内容标签定义";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(214, 351);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(57, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(151, 351);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtRulename);
            this.groupBox2.Controls.Add(this.rtxtRegex);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnOk);
            this.groupBox2.Controls.Add(this.rtxtEnd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rtxtBegin);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.rbtnRegex);
            this.groupBox2.Controls.Add(this.rbtnBeginend);
            this.groupBox2.Location = new System.Drawing.Point(324, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 383);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "提取数据方式";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(207, 351);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(57, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rtxtEnd
            // 
            this.rtxtEnd.Location = new System.Drawing.Point(17, 224);
            this.rtxtEnd.Name = "rtxtEnd";
            this.rtxtEnd.Size = new System.Drawing.Size(311, 121);
            this.rtxtEnd.TabIndex = 7;
            this.rtxtEnd.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "开始字符串:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "结束字符串:";
            // 
            // rtxtBegin
            // 
            this.rtxtBegin.Location = new System.Drawing.Point(15, 64);
            this.rtxtBegin.Name = "rtxtBegin";
            this.rtxtBegin.Size = new System.Drawing.Size(311, 128);
            this.rtxtBegin.TabIndex = 3;
            this.rtxtBegin.Text = "";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(202, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(71, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "标签组合";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // rbtnRegex
            // 
            this.rbtnRegex.AutoSize = true;
            this.rbtnRegex.Location = new System.Drawing.Point(105, 20);
            this.rbtnRegex.Name = "rbtnRegex";
            this.rbtnRegex.Size = new System.Drawing.Size(71, 16);
            this.rbtnRegex.TabIndex = 1;
            this.rbtnRegex.Text = "正则提取";
            this.rbtnRegex.UseVisualStyleBackColor = true;
            this.rbtnRegex.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtnBeginend
            // 
            this.rbtnBeginend.AutoSize = true;
            this.rbtnBeginend.Checked = true;
            this.rbtnBeginend.Location = new System.Drawing.Point(15, 20);
            this.rbtnBeginend.Name = "rbtnBeginend";
            this.rbtnBeginend.Size = new System.Drawing.Size(71, 16);
            this.rbtnBeginend.TabIndex = 0;
            this.rbtnBeginend.TabStop = true;
            this.rbtnBeginend.Text = "前后截取";
            this.rbtnBeginend.UseVisualStyleBackColor = true;
            this.rbtnBeginend.CheckedChanged += new System.EventHandler(this.rbtnBeginend_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew,
            this.tsbtnOpen,
            this.tsbtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(681, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNew.Image")));
            this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(52, 22);
            this.tsbtnNew.Text = "新建";
            this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpen.Image")));
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(52, 22);
            this.tsbtnOpen.Text = "打开";
            this.tsbtnOpen.Click += new System.EventHandler(this.tsbtnOpen_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(52, 22);
            this.tsbtnSave.Text = "保存";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "正则表达式:";
            this.label3.Visible = false;
            // 
            // rtxtRegex
            // 
            this.rtxtRegex.Location = new System.Drawing.Point(15, 62);
            this.rtxtRegex.Name = "rtxtRegex";
            this.rtxtRegex.Size = new System.Drawing.Size(311, 283);
            this.rtxtRegex.TabIndex = 10;
            this.rtxtRegex.Text = "";
            this.rtxtRegex.Visible = false;
            // 
            // txtRulename
            // 
            this.txtRulename.Location = new System.Drawing.Point(72, 353);
            this.txtRulename.Name = "txtRulename";
            this.txtRulename.Size = new System.Drawing.Size(113, 21);
            this.txtRulename.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "规则名称:";
            // 
            // FrmRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 435);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRule";
            this.Text = "FrmRule";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView rulelist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtBegin;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton rbtnRegex;
        private System.Windows.Forms.RadioButton rbtnBeginend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RichTextBox rtxtEnd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtRegex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRulename;
    }
}