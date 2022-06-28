using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
static class card
{
    static public void etebarsanji_card(this string x)
    {
        if (x.Length != 16)
        {
            throw new Exception("");
        }
        int javab = 0;
        for(int i = 0; i < x.Length; i++)
        {
            if (i % 2 == 0)
            {
                javab += int.Parse(x[i].ToString());
            }
            else
            {
                int y = (int.Parse(x[i].ToString()) * 2) % 10;
                int z = (int.Parse(x[i].ToString()) * 2) / 10;
                javab =javab+ z + y;
            }
        }
        if (javab % 10 != 0)
        {
            throw new Exception("");
        }
    }
}
namespace MainDatas
{
    public class Bank_Card
    {
        public static ObservableCollection<Bank_Card> cards = new ObservableCollection<Bank_Card>();
        public static ObservableCollection<int> ids = new ObservableCollection<int>();
        public int ID { get; set; }
        public string CVV { get; private set; }
        public int mah_engheza { get;private set; }
        public int sal_engheza { get;private set; }
        public string shomare_kart { get;private set; }
        public static void Extractcarddata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\carddata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string extract = "Select * From cards";
            SqlDataAdapter adapter = new SqlDataAdapter(extract, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int a = (int)table.Rows[i][0];
                string b = table.Rows[i][1].ToString();
                int c = (int)table.Rows[i][2];
                int d = (int)table.Rows[i][3];
                string e = table.Rows[i][4].ToString();
                Bank_Card help = new Bank_Card(a, b, d,c,e, false);
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Bank_Card(int id, string cVV, int mah_engheza, int sal_engheza, string shomare_kart,bool x)
        {
            if (ids.Contains(id))
                throw new Exception("This Id had already token");
            ID = id;
            Regex r = new Regex(@"^\d{3,4}$");
            if (r.IsMatch(cVV))
                CVV = cVV;
            else
                throw new Exception("Invalid CVV");
            if (mah_engheza < 1 || mah_engheza > 12)
                throw new Exception("");
            if (sal_engheza < (DateTime.Now.Year - 621))
                throw new Exception("");
            else if(sal_engheza == (DateTime.Now.Year - 621))
            {
                if (mah_engheza < DateTime.Now.Month)
                {
                    throw new Exception("");
                }
            }
            this.mah_engheza = mah_engheza;
            this.sal_engheza = sal_engheza;
            shomare_kart.etebarsanji_card();
            this.shomare_kart = shomare_kart;
            ids.Add(id);
            cards.Add(this);
            if (x)
            {
                SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\carddata.mdf;Integrated Security=True;Connect Timeout=30");
                put.Open();
                string command = "Insert into cards values('" + id + "','" + cVV.Trim()+ "','" + sal_engheza + "','" + mah_engheza + "','" + shomare_kart.Trim() + "') ";
                SqlCommand doo = new SqlCommand(command, put);
                doo.BeginExecuteNonQuery();
                put.Close();
            }
        }
    }
}
