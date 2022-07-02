using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdminUI : Window
    {
        Admin admin;
        int i = 0;
        public AdminUI(Admin admin)
        {
            InitializeComponent();
            //Book.ExtractBookdata();
            Book z = new Book(123455678, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            Book y = new Book(12345567, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
            //Book x = new Book(1234556, "raz", "hogo", "itsgood", 120, @"C:\Users\win_10\BookStore\Project\MainDatas\images\Add_vip.png", @"C:\Users\win_10\Desktop\New Document(57) 15-Jun-2022 21-30-57 Page 1.pdf", true);
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
            Customer c = new Customer("aligholami@gmil.com", "123DaDa_123", false);
            c.Firstname = "ali";
            c.Lastname = "gholami";
            userlistvip.ItemsSource = CustomerPo.customersvip;
            userlistadi.ItemsSource = CustomerPo.customersadi;
            this.bookdata.ItemsSource = Book.books;
            this.admin = admin;
        }

        private void click_btn(object sender, RoutedEventArgs e)
        {
            if (menu.SelectedIndex == 1)
            {
                menu.SelectedIndex = 0;
            }
            else
            {
                menu.SelectedIndex = 1;
            }
        }
        private void Edit_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 2;
        }
        private void User_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 3;
        }
        ObservableCollection<Book> dataa1 = new ObservableCollection<Book>();
        private void Search_click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (searchbookbox.Text != "")
                {
                    menu.SelectedIndex = 4;
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

        private void Add_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 5;
        }
        private void EditB_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 5;
        }
        private void VIP_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 6;
        }
        private void Discount_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 7;
        }
        private void Money_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 8;
        }
        private void Home_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 0;
        }

        private void tagheer_etelaat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (First_name != null)
                {
                    admin.Firstname = First_name.Text;
                }
                if (last_name != null)
                {
                    admin.Lastname = last_name.Text;
                }
                if (phon_number != null)
                {
                    admin.Phonenumber = phon_number.Text;
                }
                if (new_paas != null)
                {
                    if (old_pass == null || old_pass.Password != admin.Password)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bookdatasearch_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int montakhab = searchbook.SelectedIndex;
            BookAdmin x = new BookAdmin(admin, dataa1[montakhab]);
            x.Show();
        }
        private void ezafekardan_ketab_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (id == null || book_name == null || name_nevisande == null || tozihat == null || adress_aks == null || Adress_pdf == null)
                {
                    throw new Exception("");
                }
                int ID = int.Parse(id.Text);
                float Gheymat = float.Parse(gheymat_ketab.Text);
                Book x = new Book(ID, book_name.Text, name_nevisande.Text, tozihat.Text, Gheymat, adress_aks.Text, Adress_pdf.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void editinforB_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void deletB_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void vipb_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void discountb_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void bookdata_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int montakhab = bookdata.SelectedIndex;
            if (montakhab >= 0)
            {
                BookAdmin x = new BookAdmin(admin, Book.books[montakhab]);
                x.Show();
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
                    menu.SelectedIndex = 9;
                    List<Customer> data = Customer.customers.Where(x => (x.Firstname.Contains(searchbox.Text)&& x.Firstname!="") || x.Lastname.Contains(searchbox.Text) || x.Emailaddress.Contains(searchbox.Text)).ToList();
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
        static public void remove(Book b)
        {
            Book.books.Remove(b);
        }

        private void ezafekardan_vip(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rooz_vip == null || gheymat_vip == null)
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
                if (rooz_vip == null || gheymat_vip == null)
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
    }

}
