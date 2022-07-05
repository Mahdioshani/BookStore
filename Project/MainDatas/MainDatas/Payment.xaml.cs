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
using System.Text.RegularExpressions;

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        Customer x;
        float t;
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
        public Payment(Customer x, float t)
        {
            InitializeComponent();
            this.x = x;
            this.t = t;
        }

        private void Mm_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Id.Text != "")
                    etebarsanji_card(Id.Text);
                else
                    throw new Exception("The Id No is empty");
                int y = int.Parse(year.Text);
                int m = int.Parse(month.Text);
                int d = int.Parse(day.Text);
                if (d > 31 || d == 0)
                {
                    throw new Exception("Invalid Exp.date");
                }
                if (m > 12 || d == 0)
                {
                    throw new Exception("Invalid Exp.date");
                }

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
                    if (DateTime.Now.Month == m)
                    {
                        if (DateTime.Now.Day > d)
                        {
                            throw new Exception("Invalid Exp.Date");
                        }
                    }
                }
                Regex r = new Regex(@"^\d{3,4}$");
                if (!r.IsMatch(cvv.Password))
                    throw new Exception("Invalid CVV");
                Regex r1 = new Regex(@"^\d{6}$");
                if (!r1.IsMatch(passwd.Password))
                    throw new Exception("Invalid Card Password");
                x.mojoodi += t;
                MessageBox.Show("Payment Completed","Check",MessageBoxButton.OK,MessageBoxImage.Information);
                this.Close();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message, "Wrong!!!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
