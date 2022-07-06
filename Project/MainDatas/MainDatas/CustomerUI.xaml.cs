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
        bool show = true;
       // public ObservableCollection<Book> Cartdata = new ObservableCollection<Book>();
        static int i = 0;

        public CustomerUI(Customer bb)
        {
            InitializeComponent();
            vt = bb;
            Allbooks.DataContext = this;
            mojodi.Content = vt.mojoodi + " $";
            LL.Content = Admin.gheymat_vip + " $";
            // Book x = new Book(123456, "raz", "hogo", "itsgood", 120, @"C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\karen\Desktop\mahdi UNI\term 2\gosaste\HW4_{400521117}.pdf",false)
            Allbooks.ItemsSource = Book.books.Where(x => !x.IsVIP);
            Cartbooks.ItemsSource = vt.SabadKharid;
            Bookmarks.ItemsSource = vt.Books_mored_alaghe;
            BoughtBooks.ItemsSource = vt.books;
            if (vt.vip == true)
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
            try
            {
                List<Book> nn = Book.books.Where(x => !x.IsVIP).ToList();
                int f = Allbooks.SelectedIndex;
                if (f != -1)
                {
                    DataShower mm = new DataShower(vt, nn[f]);
                    mm.Show();
                    Allbooks.SelectedIndex = -1;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cartbooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int f = Cartbooks.SelectedIndex;
                if (vt.SabadKharid.Count != 0 && f != -1 && show)
                {
                    DataShower nn = new DataShower(vt.SabadKharid[f], vt);
                    nn.Show();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchh.Text != "")
                {
                    List<Book> data = Book.books.Where(x => (x.Name_ketab.Contains(searchh.Text) || x.Name_nevisande.Contains(searchh.Text))&&x.IsVIP==false).ToList();
                    ObservableCollection<Book> dataa = new ObservableCollection<Book>();
                    for (int i = 0; i < data.Count; i++)
                    {
                        dataa.Add(data[i]);
                    }
                    Allbooks.ItemsSource = dataa;
                }
                else
                {
                    List<Book> data = Book.books.Where(x =>x.IsVIP == false).ToList();
                    ObservableCollection<Book> dataa = new ObservableCollection<Book>();
                    for (int i = 0; i < data.Count; i++)
                    {
                        dataa.Add(data[i]);
                    }
                    Allbooks.ItemsSource = dataa;
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
                payment.ShowDialog();
                mojodi.Content = vt.mojoodi + " $";
                vt.rikhtan_dar_sql_mojoodi();
            }
            if (thirty.IsChecked == true)
            {
                Payment payment = new Payment(vt, 30);
                payment.ShowDialog();
                mojodi.Content = vt.mojoodi + " $";
                vt.rikhtan_dar_sql_mojoodi();
            }
            if (OneHundred.IsChecked == true)
            {
                Payment payment = new Payment(vt, 100);
                payment.ShowDialog();
                mojodi.Content = vt.mojoodi + " $";
                vt.rikhtan_dar_sql_mojoodi();
            }
            if (Custom.IsChecked == true)
            {
                try
                {
                    float t = float.Parse(iop.Text);
                    Payment payment = new Payment(vt, t);
                    payment.ShowDialog();
                    mojodi.Content = vt.mojoodi + " $";
                    vt.rikhtan_dar_sql_mojoodi();
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
                bb.ShowDialog();
                if (vt.mojoodi - p == Admin.gheymat_vip)
                {
                    vt.mojoodi -= Admin.gheymat_vip;
                    Admin.mojoodi_froshgah += Admin.gheymat_vip;
                    mojodi.Content = vt.mojoodi + " $";
                    vt.vip = true;
                    vt.start = DateTime.Now;
                    vt.end = DateTime.Now.AddDays(Admin.rooz_vip);
                    vt.sqlVipChanger();
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
                    Admin.mojoodi_froshgah += Admin.gheymat_vip;
                    mojodi.Content = vt.mojoodi + " $";
                    vt.vip = true;
                    vt.start = DateTime.Now;
                    vt.end = DateTime.Now.AddDays(Admin.rooz_vip);
                    vt.sqlVipChanger();
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
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            try
            {
                if (lastname.Text != "")
                {
                    vt.Lastname = lastname.Text;
                }
            }
            catch (Exception e1)
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
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            try
            {
                if (oldpass.Text != "")
                {
                    if (oldpass.Text == vt.Password)
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
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        

        private void Bookmarks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int f = Bookmarks.SelectedIndex;
                if (f != -1)
                {
                    DataShower nn = new DataShower(vt.Books_mored_alaghe[f], vt);
                    nn.Show();
                    Bookmarks.SelectedIndex = -1;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void BoughtBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int f = BoughtBooks.SelectedIndex;
                if (f != -1)
                {
                    DataShower nn = new DataShower(vt.books[f], vt);
                    nn.Show();
                    BoughtBooks.SelectedIndex = -1;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                float price = 0;
                List<int> save = new List<int>();
                for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                {
                    for (int j = 0; j < Cartbooks.Items.Count; j++)
                    {
                        if (Cartbooks.SelectedItems[i] == Cartbooks.Items[j])
                        {
                            price += vt.SabadKharid[j].gheymat_forosh_va_daramad(DateTime.Now);
                            save.Add(j);
                        }
                    }
                }
                if (vt.mojoodi < price)
                {
                    throw new Exception("The Wallet money is not enough");
                }
                else
                {
                    vt.mojoodi -= price;
                    Admin.mojoodi_froshgah += price;
                    for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                    {
                       vt.SabadKharid[save[i]].daramad_forosh+=vt.SabadKharid[save[i]].gheymat_forosh_va_daramad(DateTime.Now);
                        vt.SabadKharid[save[i]].tedad_forosh++;
                        vt.SabadKharid[save[i]].rikhtan_daramad_dar_sql();
                    }

                }
                for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                {
                    vt.books.Add(vt.SabadKharid[save[i]]);
                }
                save.OrderBy(x => x);
                show = false;
                for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                {
                    vt.SabadKharid.Remove(vt.SabadKharid[save[i]]);
                }
                show = false;
                mojodi.Content = vt.mojoodi + " $";
                vt.rikhtan_dar_sql_mojoodi();
                vt.rikhtan_dar_sql_ketabha_kharidari_shode();
                vt.rikhtan_dar_sql_sabadKharid();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                float price = 0;
                List<int> save = new List<int>();
                for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                {
                    for (int j = 0; j < Cartbooks.Items.Count; j++)
                    {
                        if (Cartbooks.SelectedItems[i] == Cartbooks.Items[j])
                        {
                            price += vt.SabadKharid[j].gheymat_forosh_va_daramad(DateTime.Now);
                            save.Add(j);
                        }
                    }
                }
                float bb = vt.mojoodi;
                Payment xo = new Payment(vt, price);
                xo.ShowDialog();
                if (vt.mojoodi - bb == price)
                {
                    vt.mojoodi -= price;
                    Admin.mojoodi_froshgah += price;
                    for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                    {
                        vt.books.Add(vt.SabadKharid[save[i]]);
                    }
                    for (int i = 0; i < Cartbooks.SelectedItems.Count; i++)
                    {
                        vt.SabadKharid[save[i]].daramad_forosh += vt.SabadKharid[save[i]].gheymat_forosh_va_daramad(DateTime.Now);
                        vt.SabadKharid[save[i]].tedad_forosh++;
                        vt.SabadKharid[save[i]].rikhtan_daramad_dar_sql();
                    }
                    save.Sort();
                    save.Reverse();
                    show = false;
                    for (int i = 0; i < save.Count; i++)
                    {
                        vt.SabadKharid.Remove(vt.SabadKharid[save[i]]);
                    }
                    show = true;
                    vt.rikhtan_dar_sql_ketabha_kharidari_shode();
                    vt.rikhtan_dar_sql_sabadKharid();
                }
                else
                {
                    throw new Exception("The Payment Wasn't Successful");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Tgbtn_Click(object sender, RoutedEventArgs e)
        {
            if (tgbtn.IsChecked == true)
            {
                Menu.Visibility = Visibility.Visible;
                sss.Visibility = Visibility.Collapsed;
            }
            else
            {
                Menu.Visibility = Visibility.Collapsed;
                sss.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MainWindow cc = new MainWindow(true);
            cc.Show();
            this.Close();

        }
    }
}
