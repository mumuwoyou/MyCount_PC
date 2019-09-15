using TinyCsvParser;
using TinyCsvParser.Mapping;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace MyCount
{
    public class StockMapping : CsvMapping<StockModel>
    {
        
        public StockMapping()
            : base()
        {   
            try
            {
                StreamReader file = File.OpenText("stock.json");
                JsonTextReader reader = new JsonTextReader(file);
                JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                MapProperty((int)jsonObject["code"], x => x.code);
                MapProperty((int)jsonObject["name"], x => x.name);
                MapProperty((int)jsonObject["barcode"], x => x.barcode);
                MapProperty((int)jsonObject["count"], x => x.count);

            }
            catch
            {
                MessageBox.Show("配置文件错误！");
            }
            
        }


    }

    public class StockParser
    {
        public int code;
        public int name;
        public int barcode;
        public int count;
    }
}