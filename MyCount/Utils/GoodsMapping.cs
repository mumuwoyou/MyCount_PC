using TinyCsvParser;
using TinyCsvParser.Mapping;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
namespace MyCount
{
    public class GoodsMapping: CsvMapping<GoodsModel>
    {
        public GoodsMapping()
            :base()
        {try
            {
                StreamReader file = File.OpenText("goods.json");
                JsonTextReader reader = new JsonTextReader(file);
                JObject jsonObject = (JObject)JToken.ReadFrom(reader);
                MapProperty((int)jsonObject["code"], x => x.code);
                MapProperty((int)jsonObject["name"], x => x.name);
                MapProperty((int)jsonObject["barcode"], x => x.barcode);
                MapProperty((int)jsonObject["unit"], x => x.unit);
                MapProperty((int)jsonObject["content"], x => x.content);
                MapProperty((int)jsonObject["price"], x => x.price);
            }
            catch
            {
                MessageBox.Show("配置文件错误！");
            }

        }
    }
}