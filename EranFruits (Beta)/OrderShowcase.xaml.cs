using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Driver.Linq;

namespace EranFruits__Beta_
{
    /// <summary>
    /// Interaction logic for OrderShowcase.xaml
    /// </summary>
    public partial class OrderShowcase : Window
    {
        

        public OrderShowcase()
        {
            InitializeComponent();
            TimePicker.ItemsSource = new List<string> () { "היום", "השבוע", "החודש", "אי פעם"};
           
        }

        private void TimePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Requires Mongo DB connection string, DB and Collection name.
            var client = new MongoClient("");
            var collection = client.GetDatabase("").GetCollection<BsonDocument>("");

            List<Order> orders = new List<Order>();
            var EveryOrder = collection.Find(new BsonDocument()).ToList();

            foreach (var doc in EveryOrder)
            {
                Order temp = BsonSerializer.Deserialize<Order>(doc);
                orders.Add(temp);
                
            }

            if (TimePicker.SelectedItem.Equals("היום"))
            {
                IEnumerable<Order> TodaysOrders = from ex in orders
                                           where ex.DeliveryDate.Date == DateTime.Today.Date
                                           select ex;
               OrderDisplay.ItemsSource = TodaysOrders;
               Console.ReadLine();
            }
            else if (TimePicker.SelectedItem.Equals("השבוע"))
            {
                ObservableCollection<Order> WeeksOrders = new ObservableCollection<Order>();

                foreach (Order order in orders)       
                {
                    double var = DateTime.Now.AddDays(8).Subtract(order.DeliveryDate).TotalDays;
                    if (var >= 0 && var <= 9)
                    {
                        WeeksOrders.Add(order);
                    }
                }
                OrderDisplay.ItemsSource = WeeksOrders;
            }
            else if (TimePicker.SelectedItem.Equals("החודש"))
            {
                ObservableCollection<Order> MonthsOrders = new ObservableCollection<Order>();

                foreach (Order order in orders)
                {
                    double var = DateTime.Now.AddDays(31).Subtract(order.DeliveryDate).TotalDays;
                    if (var >= 0 && var <= 32)
                    {
                        MonthsOrders.Add(order);
                    }
                }
                OrderDisplay.ItemsSource = MonthsOrders;
            }
            else if (TimePicker.SelectedItem.Equals("אי פעם"))
            {
                
                OrderDisplay.ItemsSource = orders;
            }
        }

        private void OrderDisplay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order temp = (Order)OrderDisplay.SelectedItem;
            OrderInfo info = new OrderInfo(temp, false);
            info.Show();
        }
    }
}
