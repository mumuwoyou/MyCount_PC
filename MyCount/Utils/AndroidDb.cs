using System;
using SQLite;

namespace MyCount
{
    public class AndroidDb: SQLiteConnection
    {

        public TableQuery<GoodsModel> Goods { get { return this.Table<GoodsModel>(); } }

        public TableQuery<StockModel> Stock { get { return this.Table<StockModel>(); } }

        public TableQuery<DetailModel> StockDetail { get { return this.Table<DetailModel>(); } }

        public TableQuery<PlaceModel> Places { get { return this.Table<PlaceModel>(); } }

        public TableQuery<StatusModel> Status { get { return this.Table<StatusModel>(); } }


        public AndroidDb(string dbPath): base(dbPath)
        {
            CreateTable<GoodsModel>();
            CreateTable<StockModel>();
            CreateTable<DetailModel>();
            CreateTable<PlaceModel>();
            CreateTable<StatusModel>();
        }
    }
}