using System;
using SQLite;

namespace MyCount
{
    [Table("statusmodel")]
    public class StatusModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string status { get; set; }
    }
}
