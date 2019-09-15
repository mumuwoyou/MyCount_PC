using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCount
{
    public partial class MasterDetailForm : Form
    {
        private string dbPath;
        private string xls_Filename;
        private List<StockModel> stock;
        private List<PlaceModel> places;
        private List<DetailModel> detail;
        public MasterDetailForm()
        {
            InitializeComponent();
        }

        private void MasterDetailForm_Load(object sender, EventArgs e)
        {
            dbPath = $"{Environment.CurrentDirectory}\\testdb.db";
            xls_Filename = "";
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            List<Object[]> detaillist = new List<Object[]>();

            using (var db = new AndroidDb(dbPath))
            {
                stock = db.Stock.ToList();
                places = db.Places.ToList();

                for (int i = 0; i < stock.Count(); i++)  //遍历Stock
                {
                    int[] counts = new int[places.Count()];
                    for (int j = 0; j < places.Count(); j++)//遍历Place
                    {
                        detail = db.Query<DetailModel>("select * from detailmodel where stockmodel_id = ? and  place = ?", stock[i].Id, places[j].place);
                        if (detail.Count > 0)
                        {
                            counts[j] = detail[0].count;
                        }else
                        {
                            counts[j] = 0;
                        }
                    }
                    Object[] objDetail = new Object[] {stock[i].code,stock[i].name,stock[i].barcode,stock[i].count,counts,stock[i].sum
                                        };
                    detaillist.Add(objDetail);
                }
                ExportToExcel2(detaillist);
            }
        }

       

        private void ExportToExcel2(List<Object[]> obj)
        {
            string filePath = "detail\\Detail" + DateTime.Now.ToString("yyyyMMddhhmmssms") + ".xlsx";
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            //新建一个 Excel 工作簿
            ExcelPackage package = new ExcelPackage(fileStream);

            // 添加一个 sheet 表
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

            int rowIndex = 1;   // 起始行为 1
            int colIndex = 1;   // 起始列为 1
            worksheet.Cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[rowIndex, colIndex].Value = "代码";
            worksheet.Cells[rowIndex, colIndex].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
            worksheet.Cells[rowIndex, colIndex].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
            worksheet.Column(colIndex).Width = 11;
            worksheet.Cells[rowIndex, colIndex + 1].Value = "品名";
            worksheet.Cells[rowIndex, colIndex + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
            worksheet.Cells[rowIndex, colIndex + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
            worksheet.Column(colIndex + 1).Width = 35;
            worksheet.Cells[rowIndex, colIndex + 2].Value = "条码";
            worksheet.Cells[rowIndex, colIndex + 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
            worksheet.Cells[rowIndex, colIndex + 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
            worksheet.Column(colIndex + 2).Width = 15;
            worksheet.Cells[rowIndex, colIndex + 3].Value = "库存";
            worksheet.Cells[rowIndex, colIndex + 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
            worksheet.Cells[rowIndex, colIndex + 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
            for (int j = 0; j < places.Count(); j++)
            {
                worksheet.Cells[rowIndex, colIndex + 4 + j].Value = places[j].place;
                worksheet.Cells[rowIndex, colIndex + 4 + j].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
                worksheet.Cells[rowIndex, colIndex + 4 + j].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
            }
            worksheet.Cells[rowIndex, colIndex + 4 + places.Count()].Value = "盘点合计";
            worksheet.Cells[rowIndex, colIndex + 4 + places.Count()].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
            worksheet.Cells[rowIndex, colIndex + 4 + places.Count()].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
            worksheet.Cells[rowIndex, colIndex + 5 + places.Count()].Value = "损益";
            worksheet.Cells[rowIndex, colIndex + 5 + places.Count()].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Aqua);
            worksheet.Cells[rowIndex, colIndex + 5 + places.Count()].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));

            for (int m = 0; m < obj.Count(); m++)
            {
                worksheet.Cells[rowIndex + 1 + m, colIndex].Value = obj[m][0];
                worksheet.Cells[rowIndex + 1 + m, colIndex].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                worksheet.Cells[rowIndex + 1 + m, colIndex + 1].Value = obj[m][1];
                worksheet.Cells[rowIndex + 1 + m, colIndex + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                worksheet.Cells[rowIndex + 1 + m, colIndex + 2].Value = obj[m][2];
                worksheet.Cells[rowIndex + 1 + m, colIndex + 2].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                worksheet.Cells[rowIndex + 1 + m, colIndex + 3].Value = obj[m][3];
                worksheet.Cells[rowIndex + 1 + m, colIndex + 3].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                int[] counts = (int[])obj[m][4];
                for (int n = 0; n < counts.Length; n++)
                {
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 4 + n].Value = counts[n];
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 4 + n].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                }
                worksheet.Cells[rowIndex + 1 + m, colIndex + 4 + counts.Length].Value = obj[m][5];
                worksheet.Cells[rowIndex + 1 + m, colIndex + 4 + counts.Length].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                if ((int)obj[m][5] - (int)obj[m][3] < 0)
                {
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 5 + counts.Length].Value = (int)obj[m][5] - (int)obj[m][3];
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 5 + counts.Length].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 5 + counts.Length].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                }else
                {
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 5 + counts.Length].Value = (int)obj[m][5] - (int)obj[m][3];
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 5 + counts.Length].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                    worksheet.Cells[rowIndex + 1 + m, colIndex + 5 + counts.Length].Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.ColorTranslator.FromHtml("#0097DD"));
                }

            }

            package.Save();

            fileStream.Close();
            fileStream.Dispose();

            worksheet.Dispose();
            package.Dispose();

            ConnectXls(filePath);
            xls_Filename = filePath;
        }



        private void ConnectXls(string fileName)
        {
            
            string ConnectionString = @"provider=Microsoft.ACE.OLEDB.12.0;data source='" + fileName+ "';Extended Properties=\"Excel 12.0;HDR=YES;IMEX = 1 \"";
            OleDbConnection cn = new OleDbConnection(ConnectionString);
            OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", cn);
            DataSet dtCode = new DataSet();
            oda.Fill(dtCode);
            dataGridView1.DataSource = dtCode.Tables[0];
            oda.Dispose();
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (xls_Filename != "")
                System.Diagnostics.Process.Start(@xls_Filename);
        }
    }
}
