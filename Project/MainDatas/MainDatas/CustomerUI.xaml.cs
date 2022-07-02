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
    /// Interaction logic for CustomerUI.xaml
    /// </summary>
    public partial class CustomerUI : Window
    {
        Customer vt;
       
        public ObservableCollection<Book> Cartdata = new ObservableCollection<Book>();
        static int i = 0;
       
        public CustomerUI(Customer bb)
        {
            InitializeComponent();
            vt = bb;
            Allbooks.DataContext = this;
            mojodi.Content = vt.mojoodi+" $";
            // Book x = new Book(123456, "raz", "hogo", "itsgood", 120, @"C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\karen\Desktop\mahdi UNI\term 2\gosaste\HW4_{400521117}.pdf",false);
            Book.ExtractBookdata();
            Allbooks.ItemsSource = Book.books.Where(x => !x.IsVIP);
            Cartbooks.ItemsSource = vt.SabadKharid;
            Bookmarks.ItemsSource = vt.Books_mored_alaghe;
            BoughtBooks.ItemsSource = vt.books;
            if (vt.vip ==true)
            {

                VIPBooks.ItemsSource = Book.books.Where(x => x.IsVIP);
                GetVIP.Visibility = Visibility.Collapsed;
            }
            else
            {
                GetVIP.Visibility = Visibility.Visible;
                VIPBooks.Visibility = Visibility.Collapsed;
            }
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i % 2 == 0)
                Menu.Visibility = Visibility.Visible;
            else
                Menu.Visibility = Visibility.Collapsed;
            i++;
        }
        private void Allbooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int f = Allbooks.SelectedIndex;
            DataShower nn = new DataShower(vt, Book.books[f]);
            nn.Show();
        }

        private void Cartbooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int f = Cartbooks.SelectedIndex;
            if (vt.SabadKharid.Count != 0)
            {
                DataShower nn = new DataShower(vt.SabadKharid[f], vt);
                nn.Show();
            }
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (search.Text != "")
                {
                    List<Book> data = Book.books.Where(x => x.Name_ketab.Contains(search.Text) || x.Name_nevisande.Contains(search.Text)).ToList();
                    ObservableCollection<Book> dataa = new ObservableCollection<Book>();
                    for (int i = 0; i < data.Count; i++)
                    {
                        dataa.Add(data[i]);
                    }
                    SearchedBooks.ItemsSource = dataa;
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


        private void Custom_Checked(object sender, RoutedEventArgs e)
        {
            iop.Visibility = Visibility.Visible;
            poi.Visibility = Visibility.Visible;
        }

        private void Custom_Unchecked(object sender, RoutedEventArgs e)
        {
            iop.Visibility = Visibility.Collapsed;
            poi.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Fifty.IsChecked == true)
            {
                Payment payment = new Payment(vt, 50);
                payment.Show();
                mojodi.Content = vt.mojoodi + " $";
            }
            if (thirty.IsChecked == true)
            {
                Payment payment = new Payment(vt, 30);
                payment.Show();
                mojodi.Content = vt.mojoodi + " $";

            }
            if (OneHundred.IsChecked == true)
            {
                Payment payment = new Payment(vt, 100);
                payment.Show();
                mojodi.Content = vt.mojoodi + " $";
            }
            if (Custom.IsChecked == true)
            {
                try
                {
                    float t = float.Parse(iop.Text);
                    Payment payment = new Payment(vt,t);
                    payment.Show();
                    mojodi.Content = vt.mojoodi + " $";
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                float p = vt.mojoodi;
                Payment bb = new Payment(vt, Admin.gheymat_vip);
                bb.Show();
                if (vt.mojoodi - p == Admin.gheymat_vip)
                {
                    vt.mojoodi -= Admin.gheymat_vip;
                    mojodi.Content = vt.mojoodi + " $";
                    vt.vip = true;
                    vt.start = DateTime.Now;
                    vt.end = DateTime.Now.AddDays(Admin.rooz_vip);
                    GetVIP.Visibility = Visibility.Collapsed;
                    VIPBooks.Visibility = Visibility.Visible;
                }
                else
                {
                    throw new Exception("The request wasn't able to be done");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (vt.mojoodi >= Admin.gheymat_vip)
                {
                    vt.mojoodi -= Admin.gheymat_vip;
                    mojodi.Content = vt.mojoodi + " $";
                    vt.vip = true;
                    vt.start = DateTime.Now;
                    vt.end = DateTime.Now.AddDays(Admin.rooz_vip);
                    GetVIP.Visibility = Visibility.Collapsed;
                    VIPBooks.Visibility = Visibility.Visible;
                }
                else
                {
                    throw new Exception("Your Wallet Money Is Not Enough");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                if (firstname.Text != "")
                {
                    vt.Firstname = firstname.Text;
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            try
            {
                if (lastname.Text != "")
                {
                    vt.Lastname= lastname.Text;
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            try
            {
                if (phoneno.Text != "")
                {
                    vt.Phonenumber = phoneno.Text;
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            try
            {
                if (oldpass.Text==vt.Password)
                {
                    if (newpass.Text == confirm.Text)
                    {
                        vt.Password = newpass.Text;
                    }
                    else
                        throw new Exception("New pass and Confirm Are not the same");
                }
                else
                {
                    throw new Exception("Old pass is not true");
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
