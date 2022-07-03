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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainDatas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
       public MainWindow()
        {
            //InitializeComponent();
            // Customer.ExtractCustomersdata();
          
            //Login vv = new Login();
            //Customer vt = new Customer("Ali@Email.com", "MahdiAli", true);
            //CustomerUI vv = new CustomerUI(vt);
             Admin a = new Admin("mmm@gamil.com", "1234ALig", false, false);
            // Book x = new Book(12345, "raz", "hogo", "itsgood", 120, @"C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\images\searchbook.png", @"C:\Users\karen\Desktop\mahdi UNI\term 2\gosaste\HW4_{400521117}.pdf", false);
           AdminUI vv = new AdminUI(a);
            // DataShower vv = new DataShower(vt,x);
            //vv.Show();
            //this.Close();
            InitializeComponent();
            //Customer.ExtractCustomersdata();
            //Admin x = new Admin("hengam@bgh.com", "123456Ha_", false, true);
            //AdminUI vv = new AdminUI(x);
            //Login vv = new Login();
            vv.Show();
            this.Close();
        }
    }
}
