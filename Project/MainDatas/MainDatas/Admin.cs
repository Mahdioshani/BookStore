using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace MainDatas
{
    public class Admin
    {
        static public ObservableCollection<string> emails = new ObservableCollection<string>();
        public static float mojoodi_froshgah = 0;
        public ObservableCollection<Bank_Card> bank_Cards = new ObservableCollection<Bank_Card>();
        public string Password;
        public string Email;
        public bool Modir;
        readonly Regex Emailcheck = new Regex(@"^([\w\.\-]{1,32})@([\w\-]{1,32})((\.(\w){1,32})+)$");
        readonly Regex Passcheck = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z]).{8,40}");
        public void rikhtan_dar_sql_karthaye_banki()
        {
            string a = "";
            for (int i = 0; i < bank_Cards.Count - 1; i++)
            {
                a += bank_Cards[i].ID + ",";
            }
            a += bank_Cards[bank_Cards.Count - 1].ID;
            SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
            put.Open();
            string command = "update alladmin SET id_bank_cards = '" + a.Trim() + "' where Email='" + this.Email + "'";
            SqlCommand doo = new SqlCommand(command, put);
            doo.BeginExecuteNonQuery();
            put.Close();
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
                bool c = Convert.ToBoolean(table.Rows[i][2]);
                float d = (float)table.Rows[i][3];
                string h = Convert.ToString(table.Rows[i][4]);
                Admin help = new Admin(a, b, c, false);
                if (d != null)
                    Admin.mojoodi_froshgah = d;
                if (h != null)
                {
                    string[] x = h.Split(',');
                    for (int j = 0; j < x.Length; j++)
                    {
                        for (int k = 0; k < Bank_Card.cards.Count; k++)
                        {
                            if (int.Parse(x[j]) == Bank_Card.cards[k].ID)
                            {
                                help.bank_Cards.Add(Bank_Card.cards[k]);
                            }
                        }
                    }
                }
               
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Admin(string email, string password, bool modir, bool x)
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
                SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\admindata.mdf;Integrated Security=True;Connect Timeout=30");
                put.Open();
                string command = "Insert into alladmin values('" + email.Trim() + "','" + Password.Trim() + "','" + modir + "','" + mojoodi_froshgah+ "') ";
                SqlCommand doo = new SqlCommand(command, put);
                doo.BeginExecuteNonQuery();
                put.Close();
            }
        }
    }
}
