using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TinyCsvParser;


namespace MyCount
{
    public partial class GoodsForm : Form
    {
        public GoodsForm()
        {
            InitializeComponent();
        }
        private string dbPath;
        private void Form1_Load(object sender, EventArgs e)
        {
            dbPath = $"{Environment.CurrentDirectory}\\mycount.db";
            using (var db = new AndroidDb(dbPath))
            {
                var goods = db.Goods.ToList();
                //var goods = db.Query<GoodsModel>("select code, name, barcode, unit, content, price from GoodsModel");
                this.dataGridView1.DataSource = goods;
            }
        }



        private void BtnDel_Click(object sender, EventArgs e)
        {
            using(var db = new AndroidDb(dbPath))
            {
                int count = db.DeleteAll<GoodsModel>();

                var goods = db.Goods.ToList();
                //var goods = db.Query<GoodsModel>("select code, name, barcode, unit, content, price from GoodsModel");
                this.dataGridView1.DataSource = goods;

            }
        }

        

        

        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                CsvParserOptions csvParserOptions = new CsvParserOptions(false, ',');
                GoodsMapping csvMapper = new GoodsMapping();
                CsvParser<GoodsModel> csvParser = new CsvParser<GoodsModel>(csvParserOptions, csvMapper);
                var result = csvParser
                    .ReadFromFile(FileName, Encoding.UTF8).ToList();

                List<GoodsModel> goods = new List<GoodsModel>();
                for (int i = 0; i < result.Count; i++)
                {
                    goods.Add(result[i].Result);
                }
                using (var db = new AndroidDb(dbPath))
                {
                    int count = db.InsertAll(goods);
                    this.dataGridView1.DataSource = goods;

                }
            }
            
        }

        private void GoodsForm_Shown(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
        }
    }
}
