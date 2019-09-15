using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyCsvParser;

namespace MyCount
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }
        private string dbPath;
        private void BtnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                CsvParserOptions csvParserOptions = new CsvParserOptions(false, ',');
                StockMapping csvMapper = new StockMapping();
                CsvParser<StockModel> csvParser = new CsvParser<StockModel>(csvParserOptions, csvMapper);
                var result = csvParser
                    .ReadFromFile(FileName, Encoding.UTF8).ToList();

                List<StockModel> stock = new List<StockModel>();
                for (int i = 0; i < result.Count; i++)
                {
                    stock.Add(result[i].Result);
                }
                using (var db = new AndroidDb(dbPath))
                {
                    int count = db.InsertAll(stock);
                    this.dataGridView1.DataSource = stock;

                }
            }
            openFileDialog.Dispose();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            dbPath = $"{Environment.CurrentDirectory}\\testdb.db";
            using (var db = new AndroidDb(dbPath))
            {
                var stock = db.Stock.ToList();
                this.dataGridView1.DataSource = stock;
            }
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            using (var db = new AndroidDb(dbPath))
            {
                int count = db.DeleteAll<StockModel>();
                int detail = db.DeleteAll<DetailModel>();

                var stock = db.Stock.ToList();
                this.dataGridView1.DataSource = stock;

            }
        }

        private void StockForm_Shown(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
        }
    }
}
