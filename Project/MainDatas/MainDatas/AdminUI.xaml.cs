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
            try
            {
                InitializeComponent();
                Customer.customersadi.Clear();
                Customer.customersvip.Clear();
                for (int i = 0; i < Customer.customers.Count; i++)
                {
                    if (Customer.customers[i].vip)
                    {
                        Customer.customersvip.Add(Customer.customers[i]);
                    }
                    else
                    {
                        Customer.customersvip.Add(Customer.customers[i]);
                    }
                }
                userlistvip.ItemsSource = Customer.customersvip;
                userlistadi.ItemsSource = Customer.customersadi;
                this.bookdata.ItemsSource = Book.books;
                this.admin = admin;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                        throw new Exception("The password is not correct");
                    }
                    if (confi_paas.Password != new_paas.Password)
                    {
                        throw new Exception("the password and its repetition are not the same");
                    }
                    admin.Password = new_paas.Password;
                }
                First_name.Text = "";
                last_name.Text = "";
                phon_number.Text = "";
                new_paas.Password = "";
                old_pass.Password = "";
                confi_paas.Password = "";
                MessageBox.Show("Datas had been Changes Successfully", "completed", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    searchbook.SelectedIndex = -1;
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
                if (id.Text == "" || gheymat_ketab.Text == "" || book_name.Text == "" || name_nevisande.Text == "" || tozihat.Text == "" || adress_aks.Text == "" || Adress_pdf.Text == "" || Adress_nemoone.Text == "")
                {
                    throw new Exception("All Fields Must Be completed");
                }
                int ID = int.Parse(id.Text);
                float Gheymat = float.Parse(gheymat_ketab.Text);
                Book x = new Book(ID, book_name.Text, name_nevisande.Text, tozihat.Text, Gheymat, adress_aks.Text, Adress_pdf.Text, Adress_nemoone.Text);
                x.Voive_path = Adress_voice.Text;
                MessageBox.Show("Book Added Successfully...", "Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                id.Text = "";
                book_name.Text = "";
                name_nevisande.Text = "";
                tozihat.Text = "";
                adress_aks.Text = "";
                Adress_pdf.Text = "";
                Adress_nemoone.Text = "";
                gheymat_ketab.Text = "";
                Adress_voice.Text = "";
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
                    bookdata.SelectedIndex = -1;
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
                //int montakhab_asli = 0;
                //for (int i = 0; i < Customer.customers.Count; i++)
                //{
                //    if (CustomerPo.customersadi[montakhab].Email == Customer.customers[i].Emailaddress)
                //    {
                //        montakhab_asli = i;
                //    }
                //}
                AdminUsers x = new AdminUsers(admin, Customer.customersadi[montakhab]);
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
                //int montakhab_asli = 0;
                //for (int i = 0; i < Customer.customers.Count; i++)
                //{
                //    if (Customer.customersvip[montakhab]. == Customer.customers[i].Emailaddress)
                //    {
                //        montakhab_asli = i;
                //    }
                //}
                AdminUsers x = new AdminUsers(admin, Customer.customersvip[montakhab]);
                x.Show();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        ObservableCollection<Customer> dataa = new ObservableCollection<Customer>();
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
                        dataa.Add(data[i]);
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
                //int montakhab_asli = 0;
                //for (int i = 0; i < Customer.customers.Count; i++)
                //{
                //    if (dataa[montakhab].Email == Customer.customers[i].Emailaddress)
                //    {
                //        montakhab_asli = i;
                //    }
                //}
                AdminUsers x = new AdminUsers(admin, dataa[montakhab]);
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
                    throw new Exception("All Boxes Must be Completed");
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
                            Book.books[i].takhfif = true;
                            Book.books[i].rikhtan_takhfif_dar_sql();
                        }
                    }
                    MessageBox.Show("Discount Added Successfully...", "Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    id_ketab_t.Text = "";
                    zaman_t.Text = "";
                    darsad_takhfif.Text = "";

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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow(true);
            this.Close();
            x.Show();
        }
    }


}