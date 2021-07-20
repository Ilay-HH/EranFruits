using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EranFruits__Beta_
{
    public partial class PlaceOrder : Window
    {
        private bool ToBeUpdated;
        private ObjectId id;
        string[] Hours;
        string[] Minutes;
        public PlaceOrder(bool IsUpdated)
        {
            InitializeComponent();
            Hours = new string[24];
            for (int i = 1; i < 24; i++)
            {
                Hours[i] = i.ToString();
            }
            Hours[0] = "00";
            Hours[1] = "01";
            Hours[2] = "02";
            Hours[3] = "03";
            Hours[4] = "04";
            Hours[5] = "05";
            Hours[6] = "06";
            Hours[7] = "07";
            Hours[8] = "08";
            Hours[9] = "09";
            Minutes = new string[60];
            for (int i = 1; i < 60; i++)
            {
                Minutes[i] = i.ToString();
            }
            Minutes[0] = "00";
            Minutes[1] = "01";
            Minutes[2] = "02";
            Minutes[3] = "03";
            Minutes[4] = "04";
            Minutes[5] = "05";
            Minutes[6] = "06";
            Minutes[7] = "07";
            Minutes[8] = "08";
            Minutes[9] = "09";
            SizeIN.ItemsSource = new List<string>() { "גדול", "בינוני", "קטן" };
            HourIN.ItemsSource = Hours;
            MinuteIN.ItemsSource = Minutes;
            ToBeUpdated = IsUpdated;

        }

        private void OrderFinish_Click(object sender, RoutedEventArgs e)
        {
            //Requires Mongo DB connection string, DB and Collection name.
            var client = new MongoClient("");
            var db = client.GetDatabase("");
            var orders = db.GetCollection<BsonDocument>("");

            Order temp = new Order();
            temp.Size = SizeIN.SelectedItem.ToString();
            temp.DeliveryDate = (DateTime)DDIN.SelectedDate;
            temp.DeliveryTime = HourIN.SelectedItem + ":" + MinuteIN.SelectedItem;
            temp.OrderingDate = (DateTime)ODIN.SelectedDate;
            temp.NameOfOrder = NOOIN.Text;
            temp.OrderPN = OrderPnIN.Text;
            temp.NameOfReciver = NORIN.Text;
            temp.ReciverPN = ReceiverPnIN.Text;
            temp.OrderAdress = AdressIN.Text;
            try
            {
                temp.OrderPrice = int.Parse(OPIN.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("תכתוב רק מספרים במחיר מגש");
            }
            try
            {
                temp.DeliveryPrice = int.Parse(DPIN.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("תכתוב רק מספרים במחיר משלוח");
            }

            temp.Note = NoteIN.Text;
            if (SurpriseIN.IsChecked == true)
            {
                temp.Surprise = "כן";
            }
            else
            {
                temp.Surprise = "לא";
            }
            temp._id = id;
            if (!ToBeUpdated)
            {
                OrderInfo info = new OrderInfo(temp, true);
                info.Show();
            }
            else if (ToBeUpdated)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", temp._id);
                orders.ReplaceOne(filter, temp.ToBsonDocument());
                MessageBox.Show("BRUV");
            }
        }
        public void PlaceOrderIn(Order order)
        {


            SizeIN.SelectedItem = order.Size;
            DDIN.SelectedDate = order.DeliveryDate;
            string[] orderTime = order.DeliveryTime.Split(':');
            HourIN.SelectedItem = orderTime[0];
            MinuteIN.SelectedItem = orderTime[1];
            ODIN.SelectedDate = order.OrderingDate;
            NOOIN.Text = order.NameOfOrder;
            OrderPnIN.Text = order.OrderPN;
            NORIN.Text = order.NameOfReciver;
            ReceiverPnIN.Text = order.ReciverPN;
            AdressIN.Text = order.OrderAdress;
            OPIN.Text = order.OrderPrice.ToString();
            DPIN.Text = order.DeliveryPrice.ToString();
            NoteIN.Text = order.Note;
            id = order._id;
        }
    }
}
