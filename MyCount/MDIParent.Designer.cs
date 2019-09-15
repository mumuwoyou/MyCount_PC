namespace MyCount
{
    partial class MDIParent
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.GoodsData = new System.Windows.Forms.ToolStripMenuItem();
            this.StockData = new System.Windows.Forms.ToolStripMenuItem();
            this.Trans = new System.Windows.Forms.ToolStripMenuItem();
            this.Upload = new System.Windows.Forms.ToolStripMenuItem();
            this.Download = new System.Windows.Forms.ToolStripMenuItem();
            this.Report = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Setting,
            this.Trans,
            this.Report,
            this.toolStripMenuItem2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(843, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // Setting
            // 
            this.Setting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoodsData,
            this.StockData});
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(74, 24);
            this.Setting.Text = "数据(&D)";
            // 
            // GoodsData
            // 
            this.GoodsData.Name = "GoodsData";
            this.GoodsData.Size = new System.Drawing.Size(224, 26);
            this.GoodsData.Text = "商品数据(&G)";
            this.GoodsData.Click += new System.EventHandler(this.GoodsData_Click);
            // 
            // StockData
            // 
            this.StockData.Name = "StockData";
            this.StockData.Size = new System.Drawing.Size(224, 26);
            this.StockData.Text = "库存数据(&S）";
            this.StockData.Click += new System.EventHandler(this.StockData_Click);
            // 
            // Trans
            // 
            this.Trans.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Upload,
            this.Download});
            this.Trans.Name = "Trans";
            this.Trans.Size = new System.Drawing.Size(72, 24);
            this.Trans.Text = "传输(&T)";
            // 
            // Upload
            // 
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(224, 26);
            this.Upload.Text = "上传数据库(&U)";
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // Download
            // 
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(224, 26);
            this.Download.Text = "下载数据库(&D)";
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // Report
            // 
            this.Report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailToolStripMenuItem});
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(73, 24);
            this.Report.Text = "报表(&R)";
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.detailToolStripMenuItem.Text = "盘点明细表(&D)";
            this.detailToolStripMenuItem.Click += new System.EventHandler(this.DetailToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(14, 24);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 497);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel.Text = "状态";
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 523);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MDIParent";
            this.Text = "扫码盘点PC端";
            this.Shown += new System.EventHandler(this.MDIParent_Shown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem Setting;
        private System.Windows.Forms.ToolStripMenuItem GoodsData;
        private System.Windows.Forms.ToolStripMenuItem StockData;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Trans;
        private System.Windows.Forms.ToolStripMenuItem Upload;
        private System.Windows.Forms.ToolStripMenuItem Download;
        private System.Windows.Forms.ToolStripMenuItem Report;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
    }
}



