using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
namespace MainDatas
{
    public class Customer
    {
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public static ObservableCollection<string> emails = new ObservableCollection<string>();
        public Cart cart { get; set; }
        public VIP vip { get; set; }
        public ObservableCollection<Book> Books_mored_alaghe=new ObservableCollection<Book>();
        public string Phonenumber { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Emailaddress { get; private set; }
        public string Password { get; private set; }
        readonly Regex Emailcheck = new Regex(@"^([\w\.\-]{1,32})@([\w\-]{1,32})((\.(\w){1,32})+)$");
        readonly Regex Namecheck = new Regex(@"^[A-Za-z]{3,32}$");
        readonly Regex Phonenumbercheck = new Regex(@"^(09)[0-9]{9}$");
        readonly Regex Passcheck = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z]).{8,40}");
        public void rikhtan_dar_sql_ketabha_moredalaghe()
        {
            string a = "";
            for(int i = 0; i < Books_mored_alaghe.Count-1; i++)
            {
                a += Books_mored_alaghe[i].ID + ",";
            }
            a += Books_mored_alaghe[Books_mored_alaghe.Count - 1].ID;
            SqlConnection put = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\karen\Desktop\mahdi UNI\Project\MainDatas\MainDatas\data\shopdatas.mdf ;Integrated Security = True; Connect Timeout = 30");
            put.Open();
            string command = "update Customers SET id_mored_alaghe = '"+a.Trim()+"' where Email='"+ this.Emailaddress + "'";
            SqlCommand doo = new SqlCommand(command, put);
            doo.BeginExecuteNonQuery();
            put.Close();
        }
        public void rikhtan_dar_sql_ketabha_kharidari_shode()
        {
            string a = "";
            for (int i = 0; i < cart.Books.Count - 1; i++)
            {
                a += cart.Books[i].ID + ",";
            }
            a += cart.Books[cart.Books.Count - 1].ID;
            SqlConnection put = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\karen\Desktop\mahdi UNI\Project\MainDatas\MainDatas\data\shopdatas.mdf ;Integrated Security = True; Connect Timeout = 30");
            put.Open();
            string command = "update Customers SET id_ketab_sabad_kharid = '" + a.Trim() + "' where Email='" + this.Emailaddress + "'";
            SqlCommand doo = new SqlCommand(command, put);
            doo.BeginExecuteNonQuery();
            put.Close();
        }
        public void rikhtan_dar_sql_vip()
        {
            int a = vip.ID;
            SqlConnection put = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\karen\Desktop\mahdi UNI\Project\MainDatas\MainDatas\data\shopdatas.mdf ;Integrated Security = True; Connect Timeout = 30");
            put.Open();
            string command = "update Customers vip_id = '" + a + "' where Email='" + this.Emailaddress + "'";
            SqlCommand doo = new SqlCommand(command, put);
            doo.BeginExecuteNonQuery();
            put.Close();
        }
        public static void ExtractCustomersdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\karen\Desktop\mahdi UNI\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string extract = "Select * From Customers";
            SqlDataAdapter adapter = new SqlDataAdapter(extract, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string a = Convert.ToString(table.Rows[i][0]);
                string b = Convert.ToString(table.Rows[i][1]);
                string c = Convert.ToString(table.Rows[i][2]);
                string d = Convert.ToString(table.Rows[i][3]);
                string h = Convert.ToString(table.Rows[i][4]);
                string e = Convert.ToString(table.Rows[i][5]);
                string f = Convert.ToString(table.Rows[i][6]);
                int g =(int)table.Rows[i][7];
                Customer help = new Customer(a,b,c,d,h,false);
                if (e != null)
                {
                    string[] x = e.Split(',');
                    for (int j = 0; j < x.Length; j++)
                    {
                        for (int k = 0; k < Book.books.Count; k++)
                        {
                            if (int.Parse(x[j]) == Book.books[k].ID)
                            {
                                help.Books_mored_alaghe.Add(Book.books[k]);
                            }
                        }
                    }
                }
                if (f != null)
                {
                    string[] x = f.Split(',');
                    for (int j = 0; j < x.Length; j++)
                    {
                        for (int k = 0; k < Book.books.Count; k++)
                        {
                            if (int.Parse(x[j]) == Book.books[k].ID)
                            {
                                help.cart.Books.Add(Book.books[k]);
                            }
                        }
                    }
                }
                if (g != null)
                {
                    for (int k = 0; k < VIP.vips.Count; k++)
                    {
                        if (g == VIP.vips[k].ID)
                        {
                            help.vip = VIP.vips[k];
                        }
                    }
                }
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Customer(string email,string firstname,string lastname,string phonenumber,string passwd,bool f=true)
        {
            if (emails.Contains(email))
                throw new Exception("This email has already token");
            if (!Emailcheck.IsMatch(email))
                throw new Exception("Invalid email address");
            if (!Namecheck.IsMatch(firstname))
                throw new Exception("Invalid first name");
            if(!Namecheck.IsMatch(lastname))
                throw new Exception("Invalid last name");
            if(!Phonenumbercheck.IsMatch(phonenumber))
                throw new Exception("Invalid phone number");
            if(!Passcheck.IsMatch(passwd))
                throw new Exception("Invalid password");
            Emailaddress = email;
            Firstname = firstname;
            Lastname = lastname;
            Phonenumber = phonenumber;
            Password = passwd;
            emails.Add(email);
            customers.Add(this);
            if (f)
            {
                SqlConnection put = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\karen\Desktop\mahdi UNI\Project\MainDatas\MainDatas\data\shopdatas.mdf ;Integrated Security = True; Connect Timeout = 30");
                put.Open();
                string command = "Insert into Customers values('" + email.Trim() + "','" + Firstname.Trim() + "','" + Lastname.Trim() + "','" + Phonenumber.Trim() + "','" + Password.Trim() + "') ";
                SqlCommand doo = new SqlCommand(command, put);
                doo.BeginExecuteNonQuery();
                put.Close();
            }
        }
    
    }
}
