using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace MainDatas
{
    public class Admin
    {
        public static float gheymat_vip {get; set;}
        public static int rooz_vip { get; set;}
        static public ObservableCollection<string> emails = new ObservableCollection<string>();//
        static public ObservableCollection<Admin> admins = new ObservableCollection<Admin>();//
        public static float mojoodi_froshgah = 0;
        string password;
        public string Password//
        {
            get { return password; }
            set
            {
                if (Passcheck.IsMatch(value))
                    password = value;
                else { throw new Exception("Invalid Password"); }
            }
        }
        public string Email { get; set; }//

        readonly Regex Emailcheck = new Regex(@"^([\w\.\-]{1,32})@([\w\-]{1,32})((\.(\w){1,32})+)$");//
        readonly Regex Namecheck = new Regex(@"^[A-Za-z]{3,32}$");//
        readonly Regex Phonenumbercheck = new Regex(@"^(09)[0-9]{9}$");//
        readonly Regex Passcheck = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z]).{8,40}");//
        private string firstname;
        private string lastname;
        private String phonenum;
        public string Firstname//
        {
            get { return firstname; }
            set
            {
                if (Namecheck.IsMatch(value))
                    firstname = value;
                else { throw new Exception("Invalid FirstName");}

            }
        }
        public string Lastname//
        {
            get { return lastname; }
            set
            {
                if (Namecheck.IsMatch(value))
                    lastname = value;
                else { throw new Exception("Invalid LastName"); }
            }
        }
        public string Phonenumber//
        {
            get { return this.phonenum; }
            set
            {
                if (Phonenumbercheck.IsMatch(value))
                    this.phonenum = value;
                else { throw new Exception("Invalid phone number"); }
            }
        }
        
        public static void rikhtan_dar_sql_mojoodi_froshgah()
        {
            float a = mojoodi_froshgah;
            SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
            put.Open();
            string command = "update alladmin SET mojoodi = '" + a + "'";
            SqlCommand doo = new SqlCommand(command, put);
            doo.BeginExecuteNonQuery();
            put.Close();
        }
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
        public Admin(string email, string password, bool x)
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
                SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                put.Open();
                string command = "Insert into alladmin (Email,Password) Values('" + email.Trim() + "','" + Password.Trim() + "') ";
                SqlCommand doo = new SqlCommand(command, put);
                doo.BeginExecuteNonQuery();
                put.Close();
            }
        }
    }
}
