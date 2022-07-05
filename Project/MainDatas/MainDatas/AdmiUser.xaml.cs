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
using System.Collections.ObjectModel;

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminUsers : Window
    {
        Admin admin;
        Customer customer;
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public AdminUsers(Admin admin, Customer customer)
        {
            try
            {
                InitializeComponent();
                customer.books.Add(Book.books[0]);
                customer.books.Add(Book.books[1]);
                this.admin = admin;
                this.customer = customer;
                customers.Add(customer);
                xxxxx.ItemsSource = customers;
                bookdatauser.ItemsSource = customer.books;
                if (customer.vip == true)
                    vip.Text = "Yes";
                else
                    vip.Text = "No";
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}