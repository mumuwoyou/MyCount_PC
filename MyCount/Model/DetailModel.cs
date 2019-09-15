using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MyCount
{
    [Table("detailmodel")]
    public class DetailModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int place { get; set; }

        public int count { get; set; }

        [ForeignKey(typeof(StockModel))]
        public int O2MClassAKey { get; set; }

    }

}