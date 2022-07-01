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
        public BookAdmin( Admin A, Book x)
        {
            InitializeComponent();
            book = x;
            admin=A;
            Books.Add(book);
            xxxxx.ItemsSource = Books;
           // Image1 = @"{x.path_image}";
            //image.Source= new BitmapImage(new Uri(x.path_image, UriKind.Relative));
            //name.Text = x.Name_ketab;
            //writer.Text = x.Name_nevisande;
            //Tozihat.Text = x.Tozih_ketab;

            //image.Source ={ Image1};
            //if (mm.books.Contains(v))
            //{
            //    buy.Content = "Read";
            //}
            //else
            //{ buy.Content = v.Gheymat; }
            //if (mm.books.Contains(v))
            //{

            //}
            //else
            //{
            //    ssn.IsReadOnly = true;
            //    ssn.Value = (int)(v.emtiyaz_ketab);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (i % 2 == 0)
            {

            }
            if (i % 2 == 1)
            {

            }
            i++;
        }

        private void Ssn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {

        }






        private void ShoetOfBook_Click(object sender, RoutedEventArgs e)
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


        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
