﻿namespace Win
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.hTML2DBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dB2EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rULEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xML2EXCELToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRAWLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sINGLECRAWLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eXCELCRAWLERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tasklist = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hTML2DBMULTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripButton2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(273, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(61, 22);
            this.toolStripDropDownButton2.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "设置";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eXCELCRAWLERToolStripMenuItem,
            this.hTML2DBToolStripMenuItem,
            this.hTML2DBMULTIToolStripMenuItem,
            this.dB2EXCELToolStripMenuItem,
            this.rULEToolStripMenuItem,
            this.xML2EXCELToolStripMenuItem,
            this.cRAWLERToolStripMenuItem,
            this.sINGLECRAWLERToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "功能模块";
            // 
            // hTML2DBToolStripMenuItem
            // 
            this.hTML2DBToolStripMenuItem.Name = "hTML2DBToolStripMenuItem";
            this.hTML2DBToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.hTML2DBToolStripMenuItem.Text = "HTML2DB";
            this.hTML2DBToolStripMenuItem.Click += new System.EventHandler(this.hTML2DBToolStripMenuItem_Click);
            // 
            // dB2EXCELToolStripMenuItem
            // 
            this.dB2EXCELToolStripMenuItem.Name = "dB2EXCELToolStripMenuItem";
            this.dB2EXCELToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.dB2EXCELToolStripMenuItem.Text = "DB2EXCEL";
            this.dB2EXCELToolStripMenuItem.Click += new System.EventHandler(this.dB2EXCELToolStripMenuItem_Click);
            // 
            // rULEToolStripMenuItem
            // 
            this.rULEToolStripMenuItem.Name = "rULEToolStripMenuItem";
            this.rULEToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.rULEToolStripMenuItem.Text = "RULE";
            this.rULEToolStripMenuItem.Click += new System.EventHandler(this.rULEToolStripMenuItem_Click);
            // 
            // xML2EXCELToolStripMenuItem
            // 
            this.xML2EXCELToolStripMenuItem.Name = "xML2EXCELToolStripMenuItem";
            this.xML2EXCELToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.xML2EXCELToolStripMenuItem.Text = "XML2EXCEL";
            this.xML2EXCELToolStripMenuItem.Click += new System.EventHandler(this.xML2EXCELToolStripMenuItem_Click);
            // 
            // cRAWLERToolStripMenuItem
            // 
            this.cRAWLERToolStripMenuItem.Name = "cRAWLERToolStripMenuItem";
            this.cRAWLERToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cRAWLERToolStripMenuItem.Text = "CRAWLER";
            this.cRAWLERToolStripMenuItem.Click += new System.EventHandler(this.cRAWLERToolStripMenuItem_Click);
            // 
            // sINGLECRAWLERToolStripMenuItem
            // 
            this.sINGLECRAWLERToolStripMenuItem.Name = "sINGLECRAWLERToolStripMenuItem";
            this.sINGLECRAWLERToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.sINGLECRAWLERToolStripMenuItem.Text = "SINGLECRAWLER";
            this.sINGLECRAWLERToolStripMenuItem.Click += new System.EventHandler(this.sINGLECRAWLERToolStripMenuItem_Click);
            // 
            // eXCELCRAWLERToolStripMenuItem
            // 
            this.eXCELCRAWLERToolStripMenuItem.Name = "eXCELCRAWLERToolStripMenuItem";
            this.eXCELCRAWLERToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.eXCELCRAWLERToolStripMenuItem.Text = "WEB2HTML";
            this.eXCELCRAWLERToolStripMenuItem.Click += new System.EventHandler(this.eXCELCRAWLERToolStripMenuItem_Click);
            // 
            // tasklist
            // 
            this.tasklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasklist.FullRowSelect = true;
            this.tasklist.GridLines = true;
            this.tasklist.Location = new System.Drawing.Point(3, 17);
            this.tasklist.Name = "tasklist";
            this.tasklist.Size = new System.Drawing.Size(245, 363);
            this.tasklist.TabIndex = 1;
            this.tasklist.UseCompatibleStateImageBehavior = false;
            this.tasklist.View = System.Windows.Forms.View.Details;
            this.tasklist.DoubleClick += new System.EventHandler(this.tasklist_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tasklist);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 383);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务列表树";
            // 
            // hTML2DBMULTIToolStripMenuItem
            // 
            this.hTML2DBMULTIToolStripMenuItem.Name = "hTML2DBMULTIToolStripMenuItem";
            this.hTML2DBMULTIToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.hTML2DBMULTIToolStripMenuItem.Text = "HTML2DBMULTI";
            this.hTML2DBMULTIToolStripMenuItem.Click += new System.EventHandler(this.hTML2DBMULTIToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 422);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ListView tasklist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem hTML2DBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dB2EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cRAWLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rULEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xML2EXCELToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sINGLECRAWLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXCELCRAWLERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTML2DBMULTIToolStripMenuItem;

    }
}

