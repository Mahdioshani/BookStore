using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            // Customer.ExtractCustomersdata();
            Book.ExtractBookdata();
            Customer.ExtractCustomersdata();
            Book.votersCollect();
            Admin.ExtractAdminsdata();
            Admin.managementsqlreader();
            //Login vv = new Login();
            //Customer vt = new Customer("Ali@Email.com", "MahdiAli", true);
            //CustomerUI vv = new CustomerUI(vt);
            // Admin a = new Admin("mmm@gamil.com", "1234ALig", false);
            // Book x = new Book(12345, "raz", "hogo", "itsgood", 120, @"C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\images\searchbook.png", @"C:\Users\karen\Desktop\mahdi UNI\term 2\gosaste\HW4_{400521117}.pdf", false);
            //AdminUI vv = new AdminUI(a);
            // DataShower vv = new DataShower(vt,x);
            //vv.Show();
            //this.Close();
            // InitializeComponent();
            //Customer.ExtractCustomersdata();
            //Admin x = new Admin("hengam@bgh.com", "123456Ha_", false, true);
            //AdminUI vv = new AdminUI(x);
            //Login vv = new Login();
            // vv.Show();

            bookdata.ItemsSource = Book.books;
            //this.Close();
        }
        public MainWindow(bool t)
        {
            InitializeComponent();
            bookdata.ItemsSource = Book.books;
        }


        private void bookdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Please Log in or Register First", "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Login x = new Login();
            x.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        ObservableCollection<Book> dataa1 = new ObservableCollection<Book>();
        private void Search_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (search.Text != "")
                {
                    nnn.Visibility = Visibility.Collapsed;
                    searchh.Visibility = Visibility.Visible;
                    List<Book> data = Book.books.Where(x => x.Name_ketab.Contains(search.Text) || x.Name_nevisande.Contains(search.Text)).ToList();
                    for (int i = 0; i < dataa1.Count; i++)
                    {
                        dataa1.Remove(dataa1[i]);
                    }
                    for (int i = 0; i < data.Count; i++)
                    {
                        dataa1.Add(data[i]);
                    }
                    searchbook.ItemsSource = dataa1;
                }
                else
                {
                    throw new Exception("Null Argumant not accepted");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            nnn.Visibility = Visibility.Visible;
            searchh.Visibility = Visibility.Collapsed;
        }
    }
}
