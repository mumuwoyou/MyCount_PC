namespace MyCount
{
    partial class MasterDetailForm
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnOpenXlsx = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.条码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(513, 23);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(146, 32);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "生成明细表";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnOpenXlsx
            // 
            this.btnOpenXlsx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenXlsx.Location = new System.Drawing.Point(665, 23);
            this.btnOpenXlsx.Name = "btnOpenXlsx";
            this.btnOpenXlsx.Size = new System.Drawing.Size(139, 32);
            this.btnOpenXlsx.TabIndex = 7;
            this.btnOpenXlsx.Text = "用Excel打开";
            this.btnOpenXlsx.UseVisualStyleBackColor = true;
            this.btnOpenXlsx.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.代码,
            this.品名,
            this.条码});
            this.dataGridView1.Location = new System.Drawing.Point(3, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(813, 383);
            this.dataGridView1.TabIndex = 9;
            // 
            // 代码
            // 
            this.代码.DataPropertyName = "代码";
            this.代码.HeaderText = "代码";
            this.代码.MinimumWidth = 6;
            this.代码.Name = "代码";
            this.代码.Width = 125;
            // 
            // 品名
            // 
            this.品名.DataPropertyName = "品名";
            this.品名.HeaderText = "品名";
            this.品名.MinimumWidth = 6;
            this.品名.Name = "品名";
            this.品名.Width = 250;
            // 
            // 条码
            // 
            this.条码.DataPropertyName = "条码";
            this.条码.HeaderText = "条码";
            this.条码.MinimumWidth = 6;
            this.条码.Name = "条码";
            this.条码.Width = 125;
            // 
            // MasterDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 462);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnOpenXlsx);
            this.Name = "MasterDetailForm";
            this.Text = "盘点明细表";
            this.Load += new System.EventHandler(this.MasterDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnOpenXlsx;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 条码;
    }
}