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
            Book z = new Book(123455678, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book y = new Book(12345567, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book x = new Book(1234556, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book zt = new Book(1234556783, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book yt = new Book(123455679, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book xt = new Book(12345561, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);

            bookdata.ItemsSource = Book.books;
            //this.Close();
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
                    menu.SelectedIndex = 1;
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
            menu.SelectedIndex = 0;
        }
    }
}
