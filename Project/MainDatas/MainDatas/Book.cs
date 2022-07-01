using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
        public string path_image { get; set; }
        public string pdf_nemoone { get; set; }
        public DateTime shoro_takhfif { get; set; }
        public DateTime payan_takhfif { get; set; }
        public int mizan_takhfif { get; set; }
        public int tedad_forosh { get; set; }
        public float daramad_forosh { get; set; }
        public float emtiyaz_ketab { get; set; }
        public int tedad_emtiyaz_dahandegan { get; set; } = 0;
       public bool IsVIP { get; set; }
        public float gheymat_forosh_va_daramad(DateTime x)
        {
            float a;
            if (payan_takhfif != null && shoro_takhfif != null)
            {
                if (x <= payan_takhfif && x >= shoro_takhfif)
                {
                    a = Gheymat * (100 - mizan_takhfif) / 100;
                }
                else
                {
                    a = Gheymat;
                }
            }
            else
            {
                a = Gheymat;
            }
            daramad_forosh += a;
            tedad_forosh++;
            return a;
        }
        public float emtiyaz_va_tedad_emtiyaz_dahandegan(int a)
        {
            emtiyaz_ketab = (emtiyaz_ketab * tedad_emtiyaz_dahandegan + a) / (tedad_emtiyaz_dahandegan + 1);
            tedad_emtiyaz_dahandegan++;
            return emtiyaz_ketab;
        }
        public static void ExtractBookdata()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string extract = "Select * From Allbooks";
            SqlDataAdapter adapter = new SqlDataAdapter(extract, connection);
            DataTable Allbooks = new DataTable();
            adapter.Fill(Allbooks);
            for (int i = 0; i < Allbooks.Rows.Count; i++)
            {
                int a = Convert.ToInt32(Allbooks.Rows[i][0]);
                string b = Convert.ToString(Allbooks.Rows[i][1]);
                string c = Convert.ToString(Allbooks.Rows[i][2]);
                string d = Convert.ToString(Allbooks.Rows[i][3]);
                float h = float.Parse(Allbooks.Rows[i][4].ToString());
                string v = Convert.ToString(Allbooks.Rows[i][5]);
                string y = Convert.ToString(Allbooks.Rows[i][6]);
                Book n = new Book(a, b, c, d, h, y, v, false);
                //Book e=new Book()
                //DateTime e = (DateTime)Allbooks.Rows[i][7];
                //DateTime f = (DateTime)Allbooks.Rows[i][8];
                //int g = Convert.ToInt32(Allbooks.Rows[i][9]);
                //int m = Convert.ToInt32(Allbooks.Rows[i][10]);
                //float n = float.Parse(Allbooks.Rows[i][11].ToString());
                //float k = float.Parse(Allbooks.Rows[i][12].ToString());
                //int l = Convert.ToInt32(Allbooks.Rows[i][13]);
                //Book help = new Book(a, b, c, d, h, y, v, false);
                //if (e != null)
                //    help.shoro_takhfif = e;
                //if (f != null)
                //    help.payan_takhfif = f;
                //if (g != null)
                //    help.mizan_takhfif = g;
                //if (m != null)
                //    help.tedad_forosh = m;
                //if (n != null)
                //    help.daramad_forosh = n;
                //if (k != null)
                //    help.emtiyaz_ketab = k;
                //if (l != null)
                //    help.tedad_emtiyaz_dahandegan = l;
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void rikhtan_takhfif_dar_sql()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string command = "update Allbooks SET shoro_takhfif='" + shoro_takhfif + "' ,payan_takhfif='" + payan_takhfif + "',mizan_takhfif='" + mizan_takhfif + "' where Id='" + this.ID + "'";
            SqlCommand doo = new SqlCommand(command, connection);
            doo.BeginExecuteNonQuery();
            connection.Close();
        }
        public void rikhtan_daramad_dar_sql()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string command = "update Allbooks SET tedad_foroosh='" + tedad_forosh + "' ,daramad_forosh='" + daramad_forosh + "' where Id='" + this.ID + "'";
            SqlCommand doo = new SqlCommand(command, connection);
            doo.BeginExecuteNonQuery();
            connection.Close();
        }
        public void rikhtan_emtiyaz_dar_sql()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string command = "update Allbooks SET emtiyaz_ketab='" + emtiyaz_ketab + "' ,tedad_emtiyaz_dahandegan='" + tedad_emtiyaz_dahandegan + "' where Id='" + this.ID + "'";
            SqlCommand doo = new SqlCommand(command, connection);
            doo.BeginExecuteNonQuery();
            connection.Close();
        }
        public Book(int iD, string name_ketab, string name_nevisande, string tozih_ketab, float gheymat, string path_im, string path, bool t = true)
        {
            if (allids.Contains(iD))
                throw new Exception("This Id had already token");
            ID = iD;
            Name_ketab = name_ketab;
            Name_nevisande = name_nevisande;
            Tozih_ketab = tozih_ketab;
            Gheymat = gheymat;
            path_pdf = path;
            char[] remover = new char[] { '\\' };
            var dir_path = @"" + path_im;
            FileInfo file = new FileInfo(dir_path);
            path_image =file.FullName;
            Console.WriteLine(path_image);
            if (Directory.Exists(dir_path))
            {
               var path_imag = new DirectoryInfo(dir_path);
            }
            string[] ss = path_im.Split(remover,StringSplitOptions.RemoveEmptyEntries);
            path_image = Path.GetFullPath(path_im);
          
            //for (int i = 0; i < ss.Length; i++)
            //{
            //    path_image += (ss[i]);
            //}
            books.Add(this);
            allids.Add(iD);
            if (t)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win_10\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string command = "Insert into Allbooks(Id,Name,Writer,Introduction,Price,PDF,Image) values( "+ID+" ,'" + Name_ketab.Trim() + "','" + Name_nevisande.Trim() + "','" + Tozih_ketab.Trim() + "',"+Gheymat+",'" + path.Trim() + "','" + path_image.Trim() + "') ";
                SqlCommand doo = new SqlCommand(command, connection);
                doo.BeginExecuteNonQuery();
                connection.Close();
            }
        }
    }
}