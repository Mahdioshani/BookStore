using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MainDatas
{
    public class Admin
    {
        static float _gheymat_vip = 0;
        public static float gheymat_vip
        {
            get { return _gheymat_vip; }
            set
            {
                _gheymat_vip = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Management SET GheymatVIP = @pp";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.AddWithValue("@pp", _gheymat_vip);
                vv.UpdateCommand.Connection = data;
                data.Open();
                pp.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        static int _rooz_vip = 0;
        public static int rooz_vip
        {
            get { return _rooz_vip; }
            set
            {
                _rooz_vip = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Management SET RoozVIp = @pp";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.AddWithValue("@pp", _rooz_vip);
                vv.UpdateCommand.Connection = data;
                data.Open();
                pp.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        static public ObservableCollection<string> emails = new ObservableCollection<string>();//
        static public ObservableCollection<Admin> admins = new ObservableCollection<Admin>();//
        static float _mojoodi_froshgah = 0;
        public static float mojoodi_froshgah
        {
            get { return _mojoodi_froshgah; }
            set
            {
                _mojoodi_froshgah = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Management SET Mojoodi = @pp";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.AddWithValue("@pp", _mojoodi_froshgah);
                vv.UpdateCommand.Connection = data;
                data.Open();
                pp.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        string password;
        public string Password//
        {
            get { return password; }
            set
            {
                if (Passcheck.IsMatch(value))
                {
                    password = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update alladmin SET Password = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.AddWithValue("@pp", password);
                    vv.UpdateCommand.Parameters.AddWithValue("@ee", Email);
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    pp.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid Password"); }
            }
        }
        public string Email { get; set; }//

        readonly Regex Emailcheck = new Regex(@"^([\w\.\-]{1,32})@([\w\-]{1,32})((\.(\w){1,32})+)$");//
        readonly Regex Namecheck = new Regex(@"^[A-Za-z]{3,32}$");//
        readonly Regex Phonenumbercheck = new Regex(@"^(09)[0-9]{9}$");//
        readonly Regex Passcheck = new Regex(@"^(?=.?[A-Z])(?=.?[a-z]).{8,40}");//
        private string firstname;
        private string lastname;
        private String phonenum;
        public string Firstname//
        {
            get { return firstname; }
            set
            {
                if (Namecheck.IsMatch(value))
                {
                    firstname = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update alladmin SET Firstname = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.AddWithValue("@pp", firstname);
                    vv.UpdateCommand.Parameters.AddWithValue("@ee", Email);
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    pp.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid FirstName"); }
            }
        }
        public string Lastname//
        {
            get { return lastname; }
            set
            {
                if (Namecheck.IsMatch(value))
                {
                    lastname = value;
                    lastname = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update alladmin SET Lastname = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.AddWithValue("@pp", lastname);
                    vv.UpdateCommand.Parameters.AddWithValue("@ee", Email);
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    pp.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }

                else { throw new Exception("Invalid LastName"); }
            }
        }
        public string Phonenumber//
        {
            get { return this.phonenum; }
            set
            {
                if (Phonenumbercheck.IsMatch(value))
                {
                    this.phonenum = value;
                    SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlDataAdapter vv = new SqlDataAdapter();
                    SqlCommand pp = new SqlCommand();
                    pp.CommandText = "Update alldmin SET Phonenumber = @pp Where Email = @ee";
                    vv.UpdateCommand = pp;
                    vv.UpdateCommand.Parameters.AddWithValue("@pp", phonenum);
                    vv.UpdateCommand.Parameters.AddWithValue("@ee", Email);
                    vv.UpdateCommand.Connection = data;
                    data.Open();
                    pp.ExecuteNonQuery();
                    data.Dispose();
                    data.Close();
                }
                else { throw new Exception("Invalid phone number"); }
            }
        }

        //public static void rikhtan_dar_sql_mojoodi_froshgah()
        //{
        //    float a = mojoodi_froshgah;
        //    SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
        //    put.Open();
        //    string command = "update alladmin SET mojoodi = '" + a + "'";
        //    SqlCommand doo = new SqlCommand(command, put);
        //    doo.BeginExecuteNonQuery();
        //    put.Close();
        //}
        public static void ExtractAdminsdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string extract = "Select * From alladmin";
            SqlDataAdapter adapter = new SqlDataAdapter(extract, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string a = Convert.ToString(table.Rows[i][0]);
                string b = Convert.ToString(table.Rows[i][1]);
                string c = table.Rows[i][2].ToString();
                string d = table.Rows[i][3].ToString();
                string e = table.Rows[i][4].ToString();
                Admin help = new Admin(a, b, false);
                help.Firstname = c;
                help.Lastname = d;
                help.Phonenumber = d;
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Admin(string email, string password, bool x=true)
        {
            if (emails.Contains(email))
                throw new Exception("This email has already token");
            if (!Emailcheck.IsMatch(email))
                throw new Exception("Invalid email address");
            if (!Passcheck.IsMatch(password))
                throw new Exception("Invalid password");
            Email = email;
            Password = password;
            admins.Add(this);
            emails.Add(email);
            if (x)
            {
                SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                put.Open();
                string command = "Insert into alladmin (Email,Password) Values('" + email.Trim() + "','" + Password.Trim() + "') ";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(command, put);
                adapter.InsertCommand.BeginExecuteNonQuery();
                SqlCommand doo = new SqlCommand(command, put);
                doo.Dispose();
                put.Close();
            }

        }
    public static Admin adminfouder(string username,string password)
        {
            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].Email == username && admins[i].Password == password)
                {
                    return admins[i];
                }
            }
            throw new Exception("we don't have such a Admin");
        }
    }
}
