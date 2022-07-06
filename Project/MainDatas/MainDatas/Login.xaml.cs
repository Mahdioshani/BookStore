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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Showing_Checked(object sender, RoutedEventArgs e)
        {
            Substitue1.Text = Pass1.Password;
            Substitue1.Visibility = Visibility.Visible;
            Pass1.Visibility = Visibility.Collapsed;
        }

        private void Showing_Unchecked(object sender, RoutedEventArgs e)
        {
            Pass1.Password = Substitue1.Text;
            Substitue1.Visibility = Visibility.Collapsed;
            Pass1.Visibility = Visibility.Visible;
        }

        private void Showing2_Checked(object sender, RoutedEventArgs e)
        {
            Substitue2.Text = Pass2.Password;
            Substitue2.Visibility = Visibility.Visible;
            Pass2.Visibility = Visibility.Collapsed;
        }

        private void Showing2_Unchecked(object sender, RoutedEventArgs e)
        {
            Pass2.Password = Substitue2.Text;
            Substitue2.Visibility = Visibility.Collapsed;
            Pass2.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer x = Customer.Customer_founder(nameofUser.Text, Pass2.Password);
                CustomerUI cc = new CustomerUI(x);
                cc.Show();
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                nameofUser.Text = "";
                Pass2.Password = "";
                Substitue2.Text = "";
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Admin x = Admin.adminfouder(user1.Text, Pass1.Password);
                AdminUI cc = new AdminUI(x);
                cc.Show();
                this.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                user1.Text = "";
                Pass1.Password = "";
                Substitue1.Text = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Users.IsChecked == true)
                {
                    if (password.Password != Repeat.Password)
                        throw new Exception("The password and the repeating are not the same");
                    Customer v = new Customer(Email.Text, password.Password);
                    MessageBox.Show("Account Had been made successfully", "Welldone", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (adminn.IsChecked == true)
                {
                    if (password.Password != Repeat.Password)
                        throw new Exception("The password and the repeating are not the same");
                    Admin v = new Admin(Email.Text, password.Password);
                    MessageBox.Show("Account Had been made successfully", "Welldone", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new Exception("First Select Your Role");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Email.Text = "";
                password.Password = "";
                Repeat.Password = "";
            }
        }

        private void NameofUser2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pass2.Password += Substitue2.Text;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow bb = new MainWindow(true);
            bb.Show();
            this.Close();
        }
    }
}
