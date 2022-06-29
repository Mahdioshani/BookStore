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

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminUI : Window
    {
        int i = 0;
        public AdminUI()
        {
            InitializeComponent();
             Book.ExtractBookdata();
             Book x = new Book(12345, "raz", "hogo", "itsgood", 120, @"C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\karen\Desktop\mahdi UNI\term 2\gosaste\HW4_{400521117}.pdf",true);
            //Book.books.Add(x);
            //MessageBox.Show(Book.books.Count().ToString());
            bookdata.DataContext = this;
            
            this.bookdata.ItemsSource = Book.books;
        }

        private void click_btn(object sender, RoutedEventArgs e)
        {
            i++;
            i = i % 2;
            menu.SelectedIndex = i;
        }
        private void Edit_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 2;
        }
        private void User_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 3;
        }
        private void Search_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 4;
        }
        private void Add_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 5;
        }
        private void EditB_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 6;
        }
        private void VIP_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 7;
        }
        private void Discount_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 8;
        }
        private void Money_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 9;
        }
        private void Home_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 0;
        }
    }
}
