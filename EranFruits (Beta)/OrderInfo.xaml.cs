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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EranFruits__Beta_
{
    public partial class OrderInfo : Window
    {
        private Order currentorder;
        private bool istherewindow;
        public OrderInfo(Order order, bool windowbehind)
        {
            InitializeComponent();
            currentorder = order;
            istherewindow = windowbehind;
            SizeInfo.Text = order.Size;
            DDInfo.Text = order.DeliveryDate.ToString("yyyy-MM-dd");
            DTInfo.Text = order.DeliveryTime;
            ODInfo.Text = order.OrderingDate.ToString("yyyy-MM-dd");
            NOOInfo.Text = order.NameOfOrder;
            OrderPnInfo.Text = order.OrderPN;
            NORInfo.Text = order.NameOfReciver;
            RecieverPnInfo.Text = order.ReciverPN;
            AdressInfo.Text = order.OrderAdress;
            OrderPriceInfo.Text = order.OrderPrice.ToString();
            DeliveryPriceInfo.Text = order.DeliveryPrice.ToString();
            NoteInfo.Text = order.Note;
            SurpriseInfo.Text = order.Surprise;

        }
        

        private void OrderConfirm_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = new TimeSpan(10, 30, 0);
            currentorder.DeliveryDate = currentorder.DeliveryDate.Date + ts;
            currentorder.OrderingDate = currentorder.OrderingDate.Date + ts;
            //Requires Mongo DB and Collection name.
            MongoCRUD db = new MongoCRUD("");
            db.InsertRecord("", currentorder);
            MessageBox.Show("הזמנתך הוזנה בהצלחה");
            this.Close();
        }

        private void OrderChange_Click(object sender, RoutedEventArgs e)
        {
            if (!istherewindow)
            {
                PlaceOrder neworder = new PlaceOrder(true);
                neworder.PlaceOrderIn(currentorder);
                neworder.Show();
            }
            this.Close();
        }
    }
}
