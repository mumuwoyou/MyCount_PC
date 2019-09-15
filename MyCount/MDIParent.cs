using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCount
{
    public partial class MDIParent : Form
    {

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new StockForm();
            childForm.MdiParent = this;
            //childForm.Text = "窗口 " + childFormNumber++;

            childForm.Show();
        }


        private void GoodsData_Click(object sender, EventArgs e)
        {
            Form childForm = new GoodsForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void StockData_Click(object sender, EventArgs e)
        {
            Form childForm = new StockForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            Form childForm = new FormDataSelect(1);
            //childForm.MdiParent = this;
            childForm.Text = "上传数据库到手机";
            childForm.ShowDialog();
        }

        private void Download_Click(object sender, EventArgs e)
        {
            Form childForm = new FormDataSelect(0);
            //childForm.MdiParent = this;
            childForm.Text = "从手机下载数据库";
            childForm.ShowDialog();
        }

        private void MDIParent_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void DetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new MasterDetailForm();
            childForm.MdiParent = this;
            childForm.Show();
        }

    }
}
