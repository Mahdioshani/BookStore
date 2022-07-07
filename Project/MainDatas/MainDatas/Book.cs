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
        public ObservableCollection<Customer> Voters = new ObservableCollection<Customer>();
        public string Voive_path
        {
            get { return voicepath; }
            set
            {
                voicepath = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Allbooks SET VoicePath  = @pp Where Id = @ee";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = Voive_path;
                vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
                vv.UpdateCommand.Connection = data;
                data.Open();
                vv.UpdateCommand.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        string voicepath;
        public int ID { get; set; }
        public string saveName { get; set; }
        public string Name_ketab { get; set; }
        public string Name_nevisande { get; set; }
        public string Tozih_ketab { get; set; }
        public float Gheymat { get; set; }
        public string path_pdf { get; set; }
        public string path_image { get; set; }
        string Pdf_Nemoone;
        public string pdf_nemoone
        {
            get { return Pdf_Nemoone; }
            set
            {
                Pdf_Nemoone = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Allbooks SET PDFnemoone = @pp Where Id = @ee";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = pdf_nemoone;
                vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
                vv.UpdateCommand.Connection = data;
                data.Open();
                vv.UpdateCommand.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        public DateTime? shoro_takhfif { get; set; }
        public DateTime? payan_takhfif { get; set; }
        public int? mizan_takhfif { get; set; }
        public int tedad_forosh { get; set; }
        public float daramad_forosh { get; set; }
        float emtiyaz_k;
        public int emtiyaz { get; set; }
        public float emtiyaz_ketab
        {
            get { return emtiyaz_k; }
            set
            {
                emtiyaz_k = value;
                emtiyaz = (int)emtiyaz_k;
            }
        }
        public int tedad_emtiyaz_dahandegan { get; set; } = 0;
        public bool vip;
        public bool IsVIP
        {
            get { return vip; }
            set
            {
                vip = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Allbooks SET IsVIP = @pp Where Id = @ee";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.Bit).Value = vip;
                vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
                vv.UpdateCommand.Connection = data;
                data.Open();
                vv.UpdateCommand.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        public bool takhfif { get; set; }
        public float gheymat_forosh_va_daramad(DateTime x)
        {
            float a;
            if (payan_takhfif != null && shoro_takhfif != null)
            {
                if (x <= payan_takhfif && x >= shoro_takhfif)
                {
                    a = float.Parse((Gheymat * (100 - mizan_takhfif) / 100).ToString());
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
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
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
                Book n = new Book(a, b, c, d, h, y, v, v, false);
                string f = Convert.ToString(Allbooks.Rows[i][7]);
                string g = Convert.ToString(Allbooks.Rows[i][8]);
                string j = Convert.ToString(Allbooks.Rows[i][9]);
                bool jj = bool.Parse(Allbooks.Rows[i][17].ToString());
                if (jj == false)
                {
                    n.shoro_takhfif = null;
                    n.payan_takhfif = null;
                    n.mizan_takhfif = null;
                }
                else
                {

                    n.shoro_takhfif = DateTime.Parse(f);
                    n.payan_takhfif = DateTime.Parse(g);
                    n.takhfif = jj;
                    if (DateTime.Now > n.payan_takhfif)
                    {
                        n.payan_takhfif = null;
                        n.shoro_takhfif = null;
                        jj = false;
                        j = null;
                    }
                    else
                    {
                        n.mizan_takhfif = int.Parse(j);
                    }
                }
                string rc = Convert.ToString(Allbooks.Rows[i][10]);
                int cc = int.Parse(Allbooks.Rows[i][10].ToString());
                n.tedad_forosh = cc;
                float n1 = float.Parse(Allbooks.Rows[i][11].ToString());
                n.daramad_forosh = n1;
                float k = float.Parse(Allbooks.Rows[i][12].ToString());
                n.emtiyaz_ketab = k;
                n.pdf_nemoone = Convert.ToString(Allbooks.Rows[i][13]);
                bool jj1 = bool.Parse(Allbooks.Rows[i][14].ToString());
                n.IsVIP = jj1;
                string e = Convert.ToString(Allbooks.Rows[i][15]);
                n.saveName = e;
                string e1 = Convert.ToString(Allbooks.Rows[i][16]);
                n.voicepath = e1;
            }
            SqlCommand command = new SqlCommand(extract, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void rikhtan_takhfif_dar_sql()
        {
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Allbooks SET Takhfif = @pp , shorotakhfif = @mm , payantakhfif = @cc, mizantakhfif = @qq Where Id = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.Bit).Value = takhfif;
            if (shoro_takhfif != null)
                vv.UpdateCommand.Parameters.Add("@mm", SqlDbType.DateTime).Value = shoro_takhfif;
            else
                vv.UpdateCommand.Parameters.AddWithValue("@mm", DBNull.Value);
            if (payan_takhfif != null)
                vv.UpdateCommand.Parameters.Add("@cc", SqlDbType.DateTime).Value = payan_takhfif;
            else
                vv.UpdateCommand.Parameters.AddWithValue("@cc", DBNull.Value);
            vv.UpdateCommand.Parameters.Add("@qq", SqlDbType.Int).Value = mizan_takhfif;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public void rikhtan_daramad_dar_sql()
        {
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Allbooks SET tedadforoosh = @pp , daramadforosh = @mm  Where Id = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.Int).Value = tedad_forosh;
            vv.UpdateCommand.Parameters.Add("@mm", SqlDbType.Float).Value = daramad_forosh;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public void rikhtan_emtiyaz_dar_sql()
        {
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Allbooks SET emtiyazketab = @pp Where Id = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.Float).Value = emtiyaz_ketab;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public void rikhtan_voters()
        {
            string a = "";
            for (int i = 0; i < Voters.Count - 1; i++)
            {
                a += Voters[i].Emailaddress;
            }
            if (Voters.Count != 0)
            {
                a += Voters[Voters.Count - 1].Emailaddress;
            }
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Allbooks SET Voters = @pp Where Id = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.Add("@pp", SqlDbType.NVarChar).Value = a;
            vv.UpdateCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
            vv.UpdateCommand.Connection = data;
            data.Open();
            vv.UpdateCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public Book(int iD, string name_ketab, string name_nevisande, string tozih_ketab, float gheymat, string path_im, string path, string path_ne, bool t = true)
        {
            if (allids.Contains(iD))
                throw new Exception("This Id had already token");
            ID = iD;
            Name_ketab = name_ketab;
            Name_nevisande = name_nevisande;
            Tozih_ketab = tozih_ketab;
            Gheymat = gheymat;
            path_pdf = path;
            pdf_nemoone = path_ne;
            char[] remover = new char[] { '\\' };
            path_image = Path.GetFullPath(path_im);
            books.Add(this);
            allids.Add(iD);
            if (t)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string command = "Insert into Allbooks(Id,Name,Writer,Introduction,Price,PDF,PDFnemoone,Image) values( " + ID + " ,'" + Name_ketab.Trim() + "','" + Name_nevisande.Trim() + "','" + Tozih_ketab.Trim() + "'," + Gheymat + ",'" + path.Trim() + "','" + Pdf_Nemoone.Trim() + "','" + path_image.Trim() + "') ";
                SqlCommand doo = new SqlCommand(command, connection);
                doo.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void delete()
        {
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Delete From Allbooks Where Id = @ee";
            vv.DeleteCommand = pp;
            vv.DeleteCommand.Parameters.Add("@ee", SqlDbType.Int).Value = ID;
            vv.DeleteCommand.Connection = data;
            data.Open();
            vv.DeleteCommand.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public static void votersCollect()
        {
            for (int i = 0; i < books.Count; i++)
            {
                string[] dd = books[i].saveName.Split(',');
                for (int p = 0; p < dd.Length; p++)
                {
                    for (int j = 0; j < Customer.customers.Count; j++)
                    {
                        if (dd[p] == Customer.customers[j].Emailaddress)
                        {
                            books[i].Voters.Add(Customer.customers[j]);
                            break;
                        }
                    }

                }
                books[i].tedad_emtiyaz_dahandegan = books[i].Voters.Count;
            }
        }
    }

}