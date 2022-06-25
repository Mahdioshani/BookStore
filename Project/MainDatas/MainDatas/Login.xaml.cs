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
            Pass2.Password = Substitue1.Text;
            Substitue2.Visibility = Visibility.Collapsed;
            Pass2.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer.Customer_founder(nameofUser.Text, password.Password);
            }
            catch(Exception e1)
            {
                Pass2.Password = string.Empty;
                Substitue2.Text = string.Empty;
                nameofUser.Text = string.Empty;
                MessageBox.Show(e1.Message,"Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (password.Password != Repeat.Password)
                    throw new Exception("The password and the repeating are not the same");
                Customer v = new Customer(Email.Text, Firstname.Text, Lastname.Text, Phone.Text, password.Password);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NameofUser2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pass2.Password += Substitue2.Text;
        }
    }
}
