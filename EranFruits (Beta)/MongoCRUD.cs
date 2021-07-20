using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EranFruits__Beta_
{
    class MongoCRUD
    {
        private IMongoDatabase db;
        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb+srv://sa:KWe75xoUYVPYZfZf@cluster0.iqrrv.gcp.mongodb.net/EranFruitsDB?retryWrites=true&w=majority");
            db = client.GetDatabase("EranFruitsDB");
        }

        public void InsertRecord<T>(string table, T Record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(Record);
        }
    }
}
