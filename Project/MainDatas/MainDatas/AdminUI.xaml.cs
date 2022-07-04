using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminUI : Window
    {
        Admin admin;
        int j = 0;
        public AdminUI(Admin admin)
        {
            InitializeComponent();
            //Book.ExtractBookdata();
            Book z = new Book(123455678, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book y = new Book(12345567, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book x = new Book(1234556, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book zt = new Book(1234556783, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book yt = new Book(123455679, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book xt = new Book(12345561, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);

            //Book.books.Add(x);
            //MessageBox.Show(Book.books.Count().ToString());
            //bookdata.DataContext = this;
            CustomerPo xx = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo yy = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo zz = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo xx1 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo yy1 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo zz1 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo xx2 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo yy2 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo zz2 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo xx3 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo yy4 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo zz4 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo xx5 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo yy7 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            CustomerPo zz9 = new CustomerPo("ali", "golami", "aligholami@gmil.com", true);
            //  Customer c = new Customer("aligholami@gmil.com", "123DaDa_123", false);
            //c.Firstname = "ali";
            //c.Lastname = "gholami";
            userlistvip.ItemsSource = CustomerPo.customersvip;
            userlistadi.ItemsSource = CustomerPo.customersadi;
            this.bookdata.ItemsSource = Book.books;
            this.admin = admin;
        }
        private void click_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (j % 2 == 0)
                {
                    mm.Visibility = Visibility.Visible;
                    menu1.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mm.Visibility = Visibility.Collapsed;
                    menu1.Visibility = Visibility.Visible;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        ObservableCollection<Book> dataa1 = new ObservableCollection<Book>();
        private void Search_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchbookbox.Text != "")
                {
                    menu.SelectedIndex = 3;
                    List<Book> data = Book.books.Where(x => x.Name_ketab.Contains(searchbookbox.Text) || x.Name_nevisande.Contains(searchbookbox.Text)).ToList();
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

        private void tagheer_etelaat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (First_name.Text != "")
                {
                    admin.Firstname = First_name.Text;
                }
                if (last_name.Text != "")
                {
                    admin.Lastname = last_name.Text;
                }
                if (phon_number.Text != "")
                {
                    admin.Phonenumber = phon_number.Text;
                }
                if (new_paas.Password != "")
                {
                    if (old_pass.Password == "" || old_pass.Password != admin.Password)
                    {
                        throw new Exception("");
                    }
                    if (confi_paas.Password != new_paas.Password)
                    {
                        throw new Exception("");
                    }
                    admin.Password = new_paas.Password;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void bookdatasearch_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int montakhab = searchbook.SelectedIndex;
                if (montakhab >= 0)
                {
                    BookAdmin x = new BookAdmin(admin, dataa1[montakhab]);
                    x.ShowDialog();
                    searchbook.Items.Refresh();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ezafekardan_ketab_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id.Text == "" || book_name.Text == "" || name_nevisande.Text == "" || tozihat.Text == "" || adress_aks.Text == "" || Adress_pdf.Text == "" || Adress_nemoone.Text == "")
                {
                    throw new Exception("");
                }
                int ID = int.Parse(id.Text);
                float Gheymat = float.Parse(gheymat_ketab.Text);
                Book x = new Book(ID, book_name.Text, name_nevisande.Text, tozihat.Text, Gheymat, adress_aks.Text, Adress_pdf.Text, Adress_nemoone.Text);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void bookdata_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int montakhab = bookdata.SelectedIndex;
                if (montakhab >= 0)
                {
                    BookAdmin x = new BookAdmin(admin, Book.books[montakhab]);
                    x.ShowDialog();
                    bookdata.Items.Refresh();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void userlistadi_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int montakhab = userlistadi.SelectedIndex;
                int montakhab_asli = 0;
                for (int i = 0; i < Customer.customers.Count; i++)
                {
                    if (CustomerPo.customersadi[montakhab].Email == Customer.customers[i].Emailaddress)
                    {
                        montakhab_asli = i;
                    }
                }
                AdminUsers x = new AdminUsers(admin, Customer.customers[montakhab_asli]);
                x.Show();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void userlistvip_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int montakhab = userlistvip.SelectedIndex;
                int montakhab_asli = 0;
                for (int i = 0; i < Customer.customers.Count; i++)
                {
                    if (CustomerPo.customersvip[montakhab].Email == Customer.customers[i].Emailaddress)
                    {
                        montakhab_asli = i;
                    }
                }
                AdminUsers x = new AdminUsers(admin, Customer.customers[montakhab_asli]);
                x.Show();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        ObservableCollection<CustomerPo> dataa = new ObservableCollection<CustomerPo>();
        private void searchuser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchbox.Text != "")
                {
                    List<Customer> data = Customer.customers.Where(x => x.Firstname != "" && (x.Firstname.Contains(searchbox.Text)) || (x.Lastname != "" && x.Lastname.Contains(searchbox.Text)) || x.Emailaddress.Contains(searchbox.Text)).ToList();
                    for (int i = 0; i < dataa.Count; i++)
                    {
                        dataa.Remove(dataa[i]);
                    }
                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < CustomerPo.customers.Count; j++)
                        {
                            if (CustomerPo.customers[j].Email == data[i].Emailaddress)
                            {
                                dataa.Add(CustomerPo.customers[j]);
                            }
                        }
                    }
                    searchuser.ItemsSource = dataa;
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
        private void userlistsearch_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                int montakhab = searchuser.SelectedIndex;
                int montakhab_asli = 0;
                for (int i = 0; i < Customer.customers.Count; i++)
                {
                    if (dataa[montakhab].Email == Customer.customers[i].Emailaddress)
                    {
                        montakhab_asli = i;
                    }
                }
                AdminUsers x = new AdminUsers(admin, Customer.customers[montakhab_asli]);
                x.Show();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        static public void remove(Book b)
        {
            try
            {
                Book.books.Remove(b);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ezafekardan_vip(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rooz_vip.Text == "" || gheymat_vip.Text == "")
                {
                    throw new Exception("");
                }
                else
                {
                    Admin.rooz_vip = int.Parse(rooz_vip.Text);
                    Admin.gheymat_vip = float.Parse(gheymat_vip.Text);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void ezafekardan_discount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id_ketab_t.Text == "" || zaman_t.Text == "" || darsad_takhfif.Text == "")
                {
                    throw new Exception("");
                }
                else
                {
                    for (int i = 0; i < Book.books.Count; i++)
                    {
                        if (int.Parse(id_ketab_t.Text) == Book.books[i].ID)
                        {
                            Book.books[i].mizan_takhfif = int.Parse(darsad_takhfif.Text);
                            Book.books[i].shoro_takhfif = DateTime.Now;
                            Book.books[i].payan_takhfif = DateTime.Now.AddDays(double.Parse(zaman_t.Text));
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Exit_click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void etebarsanji_card(string x)
        {
            if (x.Length != 16)
            {
                throw new Exception("");
            }
            int javab = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (i % 2 == 0)
                {
                    javab += int.Parse(x[i].ToString());
                }
                else
                {
                    int y = (int.Parse(x[i].ToString()) * 2) % 10;
                    int z = (int.Parse(x[i].ToString()) * 2) / 10;
                    javab = javab + z + y;
                }
            }
            if (javab % 10 != 0)
            {
                throw new Exception("Invalid BankId");
            }
        }

        private void Mm_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Id.Text != "")
                    etebarsanji_card(Id.Text);
                else
                    throw new Exception("The Id No is empty");
                if (year.Text == "" || month.Text == "" || mablagh.Text == "" || passwd.Text == "" || cvv.Text == "")
                    throw new Exception();
                int y = int.Parse(year.Text);
                int m = int.Parse(month.Text);

                if (DateTime.Now.Year > y)
                {
                    throw new Exception("Invalid Exp.Date");
                }
                else if (DateTime.Now.Year == y)
                {
                    if (DateTime.Now.Month > m)
                    {
                        throw new Exception("Invalid Exp.Date");
                    }

                }
                Regex r = new Regex(@"^\d{3,4}$");
                if (!r.IsMatch(cvv.Text))
                    throw new Exception("Invalid CVV");
                Regex r1 = new Regex(@"^\d{6}$");
                if (!r1.IsMatch(passwd.Text))
                    throw new Exception("Invalid Card Password");
                if (Admin.mojoodi_froshgah < float.Parse(mablagh.Text))
                    throw new Exception("");
                Admin.mojoodi_froshgah -= float.Parse(mablagh.Text);
                MessageBox.Show("Transaction Process Completed", "ddddd", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Tgbtn_Click(object sender, RoutedEventArgs e)
        {
            if (tgbtn.IsChecked == true)
            {
                menu1.Visibility = Visibility.Visible;
                mm.Visibility = Visibility.Collapsed;
            }
            else
            {
                menu1.Visibility = Visibility.Collapsed;
                mm.Visibility = Visibility.Visible;
            }
        }
        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (searchh.Text != "")
                //{
                //    List<Book> data = Book.books.Where(x => (x.Name_ketab.Contains(searchh.Text) || x.Name_nevisande.Contains(searchh.Text)) ).ToList();
                //    ObservableCollection<Book> dataa = new ObservableCollection<Book>();
                //    for (int i = 0; i < data.Count; i++)
                //    {
                //        dataa.Add(data[i]);
                //    }
                //    Allbooks.ItemsSource = dataa;
                //}
                //else
                //{
                //    List<Book> data = Book.books.ToList();
                //    ObservableCollection<Book> dataa = new ObservableCollection<Book>();
                //    for (int i = 0; i < data.Count; i++)
                //    {
                //        dataa.Add(data[i]);
                //    }
                //    Allbooks.ItemsSource = dataa;
                //}
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }


}