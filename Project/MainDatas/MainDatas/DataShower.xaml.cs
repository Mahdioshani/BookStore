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
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;


namespace MainDatas
{
    /// <summary>
    /// Interaction logic for DataShower.xaml
    /// </summary>
    public partial class DataShower : Window
    {
        Book v;
        Customer mm;
        public DataShower(Customer c, Book x)
        {
            InitializeComponent();
            v = x;
            mm = c;
            image.Source = new BitmapImage(new Uri(@"" + x.path_image));
            name.Text = x.Name_ketab;
            writer.Text = x.Name_nevisande;
            Tozihat.Text = x.Tozih_ketab;
            if (mm.books.Contains(v))
            {
                Read.Content = "Read";
                Read.Background = Brushes.DarkGreen;
            }
            else if (mm.SabadKharid.Contains(v))
            {
                Read.Content = "Added to the Cart";
                Read.Background = Brushes.DarkGreen;
            }
            else
            { Read.Content = v.Gheymat + " Dollar"; }
            if (mm.books.Contains(v))
            {

            }
            else
            {
                ssn.IsReadOnly = true;
                ssn.Value = (int)(v.emtiyaz_ketab);
            }
            if (mm.Books_mored_alaghe.Contains(v))
            {
                bookmark.Background = Brushes.DarkGreen;
            }
            else
            {
                bookmark.Background = Brushes.DarkRed;
            }

        }
        public DataShower(Book x, Customer c)
        {
            InitializeComponent();
            v = x;
            mm = c;
            
            image.Source= new BitmapImage(new Uri(@"" + x.path_image));
            name.Text = x.Name_ketab;
            writer.Text = x.Name_nevisande;
            Tozihat.Text = x.Tozih_ketab;
            if (mm.books.Contains(v))
            {
                Read.Content = "Read";
                Read.Background = Brushes.DarkGreen;
            }
            else if (mm.SabadKharid.Contains(v))
            {
                Read.Content = "Added to the Cart";
                Read.Background = Brushes.DarkGreen;
            }
            else
            { Read.Content = v.Gheymat + " Dollar"; }
            if (mm.books.Contains(v))
            {

            }
            else
            {
                ssn.IsReadOnly = true;
                ssn.Value = (int)(v.emtiyaz_ketab);
            }

            remove.Visibility = Visibility.Visible;
            if (mm.Books_mored_alaghe.Contains(v))
            {
                bookmark.Background = Brushes.DarkGreen;
            }
            else
            {
                bookmark.Background = Brushes.DarkRed;
            }
        }



        private void Ssn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            if (!v.Voters.Contains(mm))
            {
                int x = ssn.Value;
                float f = v.tedad_emtiyaz_dahandegan * v.emtiyaz_ketab;
                v.tedad_emtiyaz_dahandegan++;
                v.emtiyaz_ketab = (f + x) / v.tedad_emtiyaz_dahandegan;
                ssn.IsReadOnly = true;
                v.Voters.Add(mm);
            }
        }
        private void Bookmark_Click(object sender, RoutedEventArgs e)
        {
            if (!mm.Books_mored_alaghe.Contains(v))
            {
                mm.Books_mored_alaghe.Add(v);
                mm.rikhtan_dar_sql_ketabha_moredalaghe();
                bookmark.Background = Brushes.DarkGreen;
            }
            else
            {
                mm.Books_mored_alaghe.Remove(v);
                mm.rikhtan_dar_sql_ketabha_moredalaghe();
                bookmark.Background = Brushes.DarkRed;
            }
        }



        private void ShoetOfBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process process = new Process();
                string file = @"" + v.pdf_nemoone;

                process.StartInfo.FileName = file;
                process.Start();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "File didn't found", MessageBoxButton.OK);
            }
        }


        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            if (mm.books.Contains(v))
            {
                try
                {
                    Process process = new Process();
                    string file = @"" + v.path_pdf;

                    process.StartInfo.FileName = file;
                    process.Start();

                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message, "File didn't found", MessageBoxButton.OK);
                }
            }
            else
            {
                if (!mm.SabadKharid.Contains(v))
                {
                    Read.Content = "Added to the Cart";
                    mm.SabadKharid.Add(v);
                    Read.Background = Brushes.DarkGreen;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mm.SabadKharid.Remove(v);
            this.Close();
        }
    }
}
