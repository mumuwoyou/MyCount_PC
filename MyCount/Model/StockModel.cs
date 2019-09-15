using System;
using SQLite;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;

namespace MyCount
{
    [Table("stockmodel")]
    public class StockModel
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public string barcode { get; set; }

        public  int count { get; set; }

        public int sum { get; set; }

        [OneToMany("O2MClassAKey")]
        public List<DetailModel> detailModels { get; set; }
    }
}