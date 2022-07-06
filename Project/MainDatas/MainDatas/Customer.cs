using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace MainDatas
{
    public class Customer
    {
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public static ObservableCollection<string> emails = new ObservableCollection<string>();
        public ObservableCollection<Book> SabadKharid = new ObservableCollection<Book>();

        public bool vip { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public float mojoodi { get; set; }

        public ObservableCollection<Book> Books_mored_alaghe = new ObservableCollection<Book>();
        public ObservableCollection<Book> books = new ObservableCollection<Book>();
        public string Phonenumber
        {
            get { return this.phonenum; }
            set
            {
                if (Phonenumbercheck.IsMatch(value) || value == "")
                {
                    this.phonenum = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update Customers SET Phonenumber = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = Phonenumber;
                    vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress;
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    vv.UpdateCommand.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid phone number"); }
            }
        }
        private string firstname;
        private string lastname;
        private String phonenum;
        public string Firstname
        {
            get { return firstname; }
            set
            {
                if (Namecheck.IsMatch(value)||value=="")
                {
                    firstname = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update Customers SET Firstname = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = firstname;
                    vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress; 
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    vv.UpdateCommand.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid FirstName"); }
            }
        }
        public string Lastname
        {
            get { return lastname; }
            set
            {
                if (Namecheck.IsMatch(value)||value == "")
                {
                    lastname = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update Customers SET Lastname = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = lastname;
                    vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress; 
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    vv.UpdateCommand.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid LastName"); }
            }
        }
        string password;
        public string Emailaddress { get; private set; }
        public string Password
        {
            get { return password; }
            set
            {
                if (Passcheck.IsMatch(value) || value == "")
                {

                    password = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update Customers SET Password = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value=password;
                    vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress;
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    vv.UpdateCommand.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid Password"); }
            }
        }
        readonly Regex Emailcheck = new Regex(@"^([\w\.\-]{1,32})@([\w\-]{1,32})((\.(\w){1,32})+)$");
        readonly Regex Namecheck = new Regex(@"^[A-Za-z]{3,32}$");
        readonly Regex Phonenumbercheck = new Regex(@"^09[0-9]{9}$");
        readonly Regex Passcheck = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z]).{8,40}");
        public void rikhtan_dar_sql_ketabha_moredalaghe()
        {

            string a = "";
            for (int i = 0; i < Books_mored_alaghe.Count - 1; i++)
            {
                a += Books_mored_alaghe[i].ID + ",";
            }
            if (Books_mored_alaghe.Count != 0)
            {
                a += Books_mored_alaghe[Books_mored_alaghe.Count - 1].ID;
            }
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Customers SET IdMoredAlaghe = @pp Where Email = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = a ;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress;
            vv.UpdateCommand.Connection = data;
            data.Open();
           vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();

        }
        public void rikhtan_dar_sql_sabadKharid()
        {

            string a = "";
            for (int i = 0; i < SabadKharid.Count - 1; i++)
            {
                a += SabadKharid[i].ID + ",";
            }
            if (SabadKharid.Count != 0)
            {
                a += SabadKharid[SabadKharid.Count - 1].ID;
            }
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Customers SET IdSabadKharid = @pp Where Email = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = a ;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();

        }
        public void rikhtan_dar_sql_ketabha_kharidari_shode()
        {
            string a = "";
            for (int i = 0; i < books.Count - 1; i++)
            {
                a += books[i].ID + ",";
            }
            if (books.Count != 0)
                a += books[books.Count - 1].ID;
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Customers SET IdKetabSabadKharid = @pp Where Email = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = a;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value = Emailaddress;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public void rikhtan_dar_sql_mojoodi()
        {
            float a = mojoodi;
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Customers SET mojoodi = @pp Where Email = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.Float).Value = a; ;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value=Emailaddress;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public static void ExtractCustomersdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
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
                string n1 = Convert.ToString(table.Rows[i][5]);
                float n = float.Parse(n1);
                string e = Convert.ToString(table.Rows[i][6]);
                string f = Convert.ToString(table.Rows[i][7]);
                string o = Convert.ToString(table.Rows[i][8]);
                string l = Convert.ToString(table.Rows[i][9]);
                string p = Convert.ToString(table.Rows[i][10]);
                Customer help = new Customer(a, h, false);
                help.Firstname = b;
                help.Lastname = c;
                help.Phonenumber = d;
                if (n != null)
                    help.mojoodi = n;
                else
                {
                    help.mojoodi = 0;
                }
                char[] cc = { ',' };
                string[] x = e.Split(cc,StringSplitOptions.RemoveEmptyEntries);
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
                x = f.Split(cc,StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < x.Length; j++)
                {
                    for (int k = 0; k < Book.books.Count; k++)
                    {
                        if (int.Parse(x[j]) == Book.books[k].ID)
                        {
                            help.books.Add(Book.books[k]);
                        }
                    }
                }
                help.vip = bool.Parse(o);
               
                if (help.vip == false)
                {
                    help.start = null;
                    help.end = null;
                }
                else
                {
                   if(l is DateTime)
                    {
                        help.start = DateTime.Parse(l);
                    }
                    else
                    {
                        help.start = null;
                    }
                    if (p is DateTime)
                    {
                        help.end = DateTime.Parse(p);
                    }
                    else
                    {
                        help.end = null;
                    }
                    if (help.end >= help.start)
                    {
                        help.end = null;
                        help.start = null;
                    }
                }
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Customer(string email, string passwd, bool f = true)
        {
            if (emails.Contains(email))
                throw new Exception("This email has already token");
            if (!Emailcheck.IsMatch(email))
                throw new Exception("Invalid email address");
            if (!Passcheck.IsMatch(passwd))
                throw new Exception("Invalid password");
            Emailaddress = email;
            password = passwd;
            emails.Add(email);
            customers.Add(this);
            mojoodi = 0;
            if (vip == false)
            {
                CustomerPo help = new CustomerPo(Lastname, Firstname, email, false);
            }
            else
            {
                CustomerPo help = new CustomerPo(Lastname, Firstname, email, true);
            }
            if (f)
            {
                SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
                put.Open();
                string command = "Insert into Customers (Email,Password,mojoodi) Values('" + email.Trim() + "','" + Password.Trim() + "',0.0) ";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(command, put);
                adapter.InsertCommand.ExecuteNonQuery();
                //SqlCommand doo = new SqlCommand(command, put);
                //doo.Dispose();
                put.Close();
            }
        }

        public static Customer Customer_founder(string email, string pass)
        {
            if (emails.Contains(email))
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    string g = customers[i].Password;
                    if (customers[i].Password == pass)
                    {
                        return customers[i];
                    }
                }
                throw new Exception("Invalid Password");
            }
            throw new Exception("We don't have such a user");
        }
        public void sqlVipChanger()
        {
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\shopdatas.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Customers SET IsVIP = @pp , Start=@mm , Endd=@cc Where Email = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.Bit).Value = vip ;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.NVarChar).Value=Emailaddress;
            vv.UpdateCommand.Parameters.Add("@mm", SqlDbType.DateTime).Value=start;
            vv.UpdateCommand.Parameters.Add("@cc",SqlDbType.DateTime).Value=end;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
    }

    public class CustomerPo
    {
        public static ObservableCollection<CustomerPo> customersvip = new ObservableCollection<CustomerPo>();
        public static ObservableCollection<CustomerPo> customersadi = new ObservableCollection<CustomerPo>();
        public static ObservableCollection<CustomerPo> customers = new ObservableCollection<CustomerPo>();
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public CustomerPo(string lastName, string firstName, string email, bool x)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            if (x == true)
            {
                customersvip.Add(this);
            }
            else
            {
                customersadi.Add(this);
            }
            customers.Add(this);
        }
        public void change()
        {
            if (customersvip.Contains(this))
            {
                customersadi.Add(this);
                customersvip.Remove(this);
            }
            else
            {
                customersadi.Remove(this);
                customersvip.Add(this);
            }
        }
    }
}

