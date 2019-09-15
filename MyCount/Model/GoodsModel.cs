using System;
using SQLite;

namespace MyCount
{
    [Table("goodsmodel")]
    public class GoodsModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string barcode { get; set; }

        public string unit { get; set; }

        public string content { get; set; }

        public float price { get; set; }

    }
   

    
}