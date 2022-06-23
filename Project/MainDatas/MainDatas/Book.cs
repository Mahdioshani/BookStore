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
   
    public class Book
    {
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();
        public static ObservableCollection<int> allids = new ObservableCollection<int>();
        public int ID { get; set; }
        public string Name_ketab { get; set; }
        public string Name_nevisande { get; set; }
        public string Tozih_ketab { get; set; }
        public float Gheymat { get; set; }
        public string path_pdf { get; set; }
        public static void ExtractCustomersdata()
        {
            SqlConnection connection = new SqlConnection();
            connection.Open();
            string extract = "Select * From booksdata";
            SqlDataAdapter adapter = new SqlDataAdapter(extract, connection);
            DataTable Allbooks = new DataTable(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf; Integrated Security = True; Connect Timeout = 30");
            adapter.Fill(Allbooks);
            for (int i = 0; i < Allbooks.Rows.Count; i++)
            {
                int a = Convert.ToInt32(Allbooks.Rows[i][0]);
                string b = Convert.ToString(Allbooks.Rows[i][1]);
                string c = Convert.ToString(Allbooks.Rows[i][2]);
                string d = Convert.ToString(Allbooks.Rows[i][3]);
                float h = float.Parse(Allbooks.Rows[i][4].ToString());
                string v = Convert.ToString(Allbooks.Rows[i][5]);
                Book help = new Book(a, b, c, d, h,v,false);
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Book(int iD, string name_ketab, string name_nevisande, string tozih_ketab, float gheymat, string path, bool t = true)
        {
            if (allids.Contains(iD))
                throw new Exception("This Id had already token");
            ID = iD;
            Name_ketab = name_ketab;
            Name_nevisande = name_nevisande;
            Tozih_ketab = tozih_ketab;
            Gheymat = gheymat;
            path_pdf = path;
            books.Add(this);
            allids.Add(iD);
            if (t)
            {
                SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf; Integrated Security = True; Connect Timeout = 30");
                connection.Open();
                string command = "Insert into Allbooks values('" + ID + "','" + Name_ketab.Trim() + "','" + Name_nevisande.Trim() + "','" + Tozih_ketab.Trim() + "','" + Gheymat + "','" + path + "') ";
                SqlCommand doo = new SqlCommand(command, connection);
                doo.BeginExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
