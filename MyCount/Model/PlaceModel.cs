using System;
using SQLite;
namespace MyCount
{
    [Table("placemodel")]
    public class PlaceModel
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string place { get; set; }
    }
}