using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class BookAdmin : Window
    {
        int i = 0;
        Book book;
        Admin admin;
        public string Image1;

        public ObservableCollection<Book> Books= new ObservableCollection<Book>();
        public BookAdmin(Admin A, Book x)
        {
            InitializeComponent();
            book = x;
            admin = A;
            Books.Add(book);
            xxxxx.ItemsSource = Books;
            if (book.IsVIP == true)
            {
                vipbtn.Background = Brushes.Green;
            }
            else
            {
                vipbtn.Background = Brushes.Red;
            }
            if (book.mizan_takhfif == 0)
            {
                discountbtn.Background = Brushes.Red;
            }
            else
            {
                discountbtn.Background = Brushes.Green;
            }
        }
        private void Ssn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            //int x = ssn.Value;
            //float f = v.tedad_emtiyaz_dahandegan * v.emtiyaz_ketab;
            //v.tedad_emtiyaz_dahandegan++;
            //v.emtiyaz_ketab = (f + x) / v.tedad_emtiyaz_dahandegan;

        }
        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Home_click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 0;
        }
        private void Edit_Click_1(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 2;
        }
        private void Delete_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            AdminUI.remove(book);
        }

        private void vip_Click_3(object sender, RoutedEventArgs e)
        {
            if (book.IsVIP == true)
            {
                vipbtn.Background= Brushes.Red;
                book.IsVIP = false;
            }
            else
            {
                vipbtn.Background = Brushes.Green;
                book.IsVIP = true;
            }
        }
        private void discount_Click_4(object sender, RoutedEventArgs e)
        {
            if (book.mizan_takhfif==0)
            {
                menu.SelectedIndex = 1;
            }
            else
            {
                discountbtn.Background = Brushes.Green;
                discounttext.Text = "Add Discount";
                book.mizan_takhfif = 0;
                book.payan_takhfif = default;
                book.shoro_takhfif = default;
            }

        }
        private void view_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Process process = new Process();
                string file = @"" + book.path_pdf;

                process.StartInfo.FileName = file;
                process.Start();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "File didn't found", MessageBoxButton.OK);
            }
        }

        private void part_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                Process process = new Process();
                string file = @"" + book.pdf_nemoone;

                process.StartInfo.FileName = file;
                process.Start();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "File didn't found", MessageBoxButton.OK);
            }
        }
        private void ezafekardan_ketab_Click(object sender, RoutedEventArgs e)
        {
            menu.SelectedIndex = 2;
        }
    }

}
