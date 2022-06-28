using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MainDatas
{
    public class VIP
    {
        public int ID { get; set; }
        public static ObservableCollection<int> ids = new ObservableCollection<int>();
       public static ObservableCollection<VIP> vips = new ObservableCollection<VIP>();
        public ObservableCollection<Book> Book_daroon_VIP = new ObservableCollection<Book>();
        public float Gheymat { get; set; }
        public int zaman_be_rooz { get; set; }
        public void rikhtan_dar_sql_ketabvip()
        {
            string a = "";
            for (int i = 0; i < Book_daroon_VIP.Count - 1; i++)
            {
                a += Book_daroon_VIP[i].ID + ",";
            }
            a += Book_daroon_VIP[Book_daroon_VIP.Count - 1].ID;
            SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\vipdata.mdf;Integrated Security=True;Connect Timeout=30");
            put.Open();
            string command = "update VIPs SET id_ketabhaye_daroon = '" + a.Trim() + "' where Id='" + this.ID + "'";
            SqlCommand doo = new SqlCommand(command, put);
            doo.BeginExecuteNonQuery();
            put.Close();
        }
        public static void ExtractVIPdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\vipdata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string extract = "Select * From VIPs";
            SqlDataAdapter adapter = new SqlDataAdapter(extract, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int a = (int)table.Rows[i][0];
                int b = (int)table.Rows[i][1];
                float c = (float)table.Rows[i][2];
                string d = Convert.ToString(table.Rows[i][3]);
                VIP help = new VIP(a,b,c,false);
                if (d != null)
                {
                    string[] x = d.Split(',');
                    for(int j = 0; j < x.Length; j++)
                    {
                        for(int k = 0; k < Book.books.Count; k++)
                        {
                            if (int.Parse(x[j]) == Book.books[k].ID)
                            {
                                help.Book_daroon_VIP.Add(Book.books[k]);
                            }
                        }
                    }
                }
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public VIP(int id, int zaman_be_rooz, float gheymat,bool x)
        {
            if (ids.Contains(id))
                throw new Exception("This Id had already token");
            ID = id;
            ids.Add(id);
            Gheymat = gheymat;
            this.zaman_be_rooz = zaman_be_rooz;
            vips.Add(this);
            if (x)
            {
                SqlConnection put = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\vipdata.mdf;Integrated Security=True;Connect Timeout=30");
                put.Open();
                string command = "Insert into VIPs values('" + id + "','" + zaman_be_rooz + "','" + gheymat + "') ";
                SqlCommand doo = new SqlCommand(command, put);
                doo.BeginExecuteNonQuery();
                put.Close();
            }
        }
    }
}
