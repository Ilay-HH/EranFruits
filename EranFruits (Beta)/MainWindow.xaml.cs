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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Driver;

namespace EranFruits__Beta_
{
    /*
     * Manager app with a database to follow orders
     * being able to open the previous order in placeorder and then change/update said order
     * having the option to write an event instead of an order
     * event having the properties of: price, event adress, event day, event working hours, name of organizer, phone of organizer 
     * make it so he can enter expenses and catagorize them
     */
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InOrder_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrder place = new PlaceOrder(false);
            place.Show();
          
        }

        private void OrderDisplay_Click(object sender, RoutedEventArgs e)
        {
            OrderShowcase showcase = new OrderShowcase();
            showcase.Show();
        }
    }
}
