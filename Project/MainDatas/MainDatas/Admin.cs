using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace MainDatas
{
    public class Admin
    {
        static public ObservableCollection<string> emails = new ObservableCollection<string>();
        public static int mojoodi_froshgah=0;
        public ObservableCollection<Bank_Card> bank_Cards = new ObservableCollection<Bank_Card>();
        public string Password;
        public string Email;
        public bool Modir;
        readonly Regex Emailcheck = new Regex(@"^([\w\.\-]{1,32})@([\w\-]{1,32})((\.(\w){1,32})+)$");
        readonly Regex Passcheck = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z]).{8,40}");

        public Admin(string email,string password,bool modir,bool x)
        {
            if (emails.Contains(email))
                throw new Exception("This email has already token");
            if (!Emailcheck.IsMatch(email))
                throw new Exception("Invalid email address");
            if (!Passcheck.IsMatch(password))
                throw new Exception("Invalid password");
            Email = email;
            Password = password;
            Modir = modir;
            if (x)
            {
                SqlConnection put = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf; Integrated Security = True; Connect Timeout = 30");
                put.Open();
                string command = "Insert into Customers values('" + email.Trim() + "','" + Password.Trim() + "','" + 0.0 + "') ";
                SqlCommand doo = new SqlCommand(command, put);
                doo.BeginExecuteNonQuery();
                put.Close();
            }
        }
    }
}
