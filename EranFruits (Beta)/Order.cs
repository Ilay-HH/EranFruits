using MongoDB.Bson;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EranFruits__Beta_
{
    public class Order
    {
        public string Size { get; set; }
        public int OrderPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public DateTime OrderingDate { get; set; }
        public string NameOfOrder { get; set; }
        public string OrderPN { get; set; }
        public string NameOfReciver { get; set; }
        public string ReciverPN { get; set; }
        public string OrderAdress { get; set; }
        public string Note { get; set; }
        public string Surprise { get; set; }
        public ObjectId _id { get; set; }

    }
    
}
