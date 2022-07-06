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

        public ObservableCollection<Book> Books = new ObservableCollection<Book>();
        public BookAdmin(Admin A, Book x)
        {
            try
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
                if (book.takhfif == false || book.payan_takhfif < DateTime.Now || book.mizan_takhfif == 0)
                {
                    discountbtn.Background = Brushes.Red;
                    discounttext.Text = "Add Discount";
                }
                else
                {
                    discountbtn.Background = Brushes.Green;
                    discounttext.Text = "Delete Discount";
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK);
            }
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
            try
            {
                this.Close();
                AdminUI.remove(book);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK);
            }
        }

        private void vip_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (book.IsVIP == true)
                {
                    vipbtn.Background = Brushes.Red;
                    book.IsVIP = false;
                   
                }
                else
                {
                    vipbtn.Background = Brushes.Green;
                    book.IsVIP = true;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK);
            }
        }
        private void discount_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                if (book.takhfif == false || book.payan_takhfif < DateTime.Now || book.mizan_takhfif == 0)
                {
                    menu.SelectedIndex = 1;
                }
                else
                {
                    discountbtn.Background = Brushes.Red;
                    discounttext.Text = "Add Discount";
                    book.mizan_takhfif = 0;
                    book.takhfif = false;
                    book.payan_takhfif = default;
                    book.shoro_takhfif = default;
                    book.rikhtan_takhfif_dar_sql();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK);
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
        private void ezafekardan_takhfif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tedad_rooz_t.Text == "" || darsad_takhfif.Text == "")
                {
                    throw new Exception("");
                }
                else
                {
                    book.shoro_takhfif = DateTime.Now;
                    book.mizan_takhfif = int.Parse(darsad_takhfif.Text);
                    book.payan_takhfif = DateTime.Now.AddDays(Double.Parse(tedad_rooz_t.Text));
                    discountbtn.Background = Brushes.Green;
                    discounttext.Text = "Delete Discount";
                    book.takhfif = true;
                    book.rikhtan_takhfif_dar_sql();
                    MessageBox.Show("Datas had been Changes Successfully", "completed", MessageBoxButton.OK, MessageBoxImage.Information);
                    tedad_rooz_t.Text = "";
                    darsad_takhfif.Text = "";
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK);
            }
        }
        private void tagheerdadan_etelaatketab_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (book_name.Text != "")
                {
                    book.Name_ketab = book_name.Text;
                }
                if (name_nevisande.Text != "")
                {
                    book.Name_nevisande = name_nevisande.Text;
                }
                if (tozihat.Text != "")
                {
                    book.Tozih_ketab = tozihat.Text;
                }
                if (gheymat_ketab.Text != "")
                {
                    book.Gheymat = float.Parse(gheymat_ketab.Text);
                }
                if (adress_aks.Text != "")
                {
                    book.path_image = adress_aks.Text;
                }
                if (Adress_pdf.Text != "")
                {
                    book.path_pdf = Adress_pdf.Text;
                }
                if (adress_nemoone.Text != "")
                {
                    book.pdf_nemoone = adress_nemoone.Text;
                }
                if (adress_seda.Text != "")
                {
                    book.Voive_path = adress_seda.Text;
                }
                xxxxx.Items.Refresh();
                MessageBox.Show("Datas had been Changes Successfully", "completed", MessageBoxButton.OK, MessageBoxImage.Information);
                book_name.Text = "";
                name_nevisande.Text = "";
                tozihat.Text = "";
                gheymat_ketab.Text = "";
                adress_aks.Text = "";
                adress_seda.Text = "";
                Adress_pdf.Text = "";
                adress_nemoone.Text = "";
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error!!", MessageBoxButton.OK);
            }
        }

        private void aidio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process process = new Process();
                string file = @"" + book.Voive_path;

                process.StartInfo.FileName = file;
                process.Start();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "File didn't found", MessageBoxButton.OK);
            }
        }
    }

}