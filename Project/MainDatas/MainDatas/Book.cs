﻿using System;
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
        public string Voive_path {
            get { return voicepath; }
            set
            {
                voicepath = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Allbooks SET VoicePath  = @pp Where Id = @ee";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.AddWithValue("@pp", voicepath);
                vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
                vv.UpdateCommand.Connection = data;
                data.Open();
                pp.ExecuteNonQuery();
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
        public string pdf_nemoone {
            get { return Pdf_Nemoone; }
            set
            {
                Pdf_Nemoone = value;
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Allbooks SET PDFnemoone = @pp Where Id = @ee";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.AddWithValue("@pp", Pdf_Nemoone);
                vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
                vv.UpdateCommand.Connection = data;
                data.Open();
                pp.ExecuteNonQuery();
                data.Dispose();
                data.Close();
            }
        }
        public DateTime? shoro_takhfif { get; set; }
        public DateTime? payan_takhfif { get; set; }
        public int? mizan_takhfif { get; set; }
        public int tedad_forosh { get; set; }
        public float daramad_forosh { get; set; }
        public float emtiyaz_ketab { get; set; }
        public int tedad_emtiyaz_dahandegan { get; set; } = 0;
        public bool vip;
        public bool IsVIP {
            get { return vip; }
            set
            {
                SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter vv = new SqlDataAdapter();
                SqlCommand pp = new SqlCommand();
                pp.CommandText = "Update Allbooks SET IsVIP = @pp Where Id = @ee";
                vv.UpdateCommand = pp;
                vv.UpdateCommand.Parameters.AddWithValue("@pp", vip);
                vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
                vv.UpdateCommand.Connection = data;
                data.Open();
                pp.ExecuteNonQuery();
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
                    a =float.Parse((Gheymat * (100 - mizan_takhfif) / 100).ToString());
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
                if (jj==false)
                {
                    n.shoro_takhfif = null;
                    n.payan_takhfif = null;
                    n.mizan_takhfif = null;
                }
                else
                {
                    if (f is DateTime)
                    {
                        n.shoro_takhfif = DateTime.Parse(f);
                    }
                    else
                    {
                        n.shoro_takhfif = null;
                    }
                    if (g is DateTime)
                    {
                        n.payan_takhfif = DateTime.Parse(g);
                    }
                    else
                    {
                        n.payan_takhfif= null;
                    }
                    if (n.payan_takhfif >= n.shoro_takhfif)
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
                n.saveName = e1;
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
            vv.UpdateCommand.Parameters.AddWithValue("@pp", takhfif);
            vv.UpdateCommand.Parameters.AddWithValue("@ee", shoro_takhfif);
            vv.UpdateCommand.Parameters.AddWithValue("@mm", payan_takhfif);
            vv.UpdateCommand.Parameters.AddWithValue("@qq", mizan_takhfif);
            vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
            vv.UpdateCommand.Connection = data;
            data.Open();
            pp.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public void rikhtan_daramad_dar_sql()
        {
            SqlConnection data = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter vv = new SqlDataAdapter();
            SqlCommand pp = new SqlCommand();
            pp.CommandText = "Update Allbooks SET tedadforoosh = @pp , daramadforoosh = @mm  Where Id = @ee";
            vv.UpdateCommand = pp;
            vv.UpdateCommand.Parameters.AddWithValue("@pp", tedad_forosh);
            vv.UpdateCommand.Parameters.AddWithValue("@mm", daramad_forosh);
            vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
            vv.UpdateCommand.Connection = data;
            data.Open();
            pp.ExecuteNonQuery();
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
            vv.UpdateCommand.Parameters.AddWithValue("@pp", emtiyaz_ketab);
            vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
            vv.UpdateCommand.Connection = data;
            data.Open();
            pp.ExecuteNonQuery();
            data.Dispose();
            data.Close();
        }
        public void rikhtan_voters()
        {
            string a = "";
            for (int i = 0; i < Voters.Count-1; i++)
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
            vv.UpdateCommand.Parameters.AddWithValue("@pp", a);
            vv.UpdateCommand.Parameters.AddWithValue("@ee", ID);
            vv.UpdateCommand.Connection = data;
            data.Open();
            pp.ExecuteNonQuery();
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
            var dir_path = @"" + path_im;
            FileInfo file = new FileInfo(dir_path);
            path_image = file.FullName;
            Console.WriteLine(path_image);
            if (Directory.Exists(dir_path))
            {
                var path_imag = new DirectoryInfo(dir_path);
            }
            string[] ss = path_im.Split(remover, StringSplitOptions.RemoveEmptyEntries);
            path_image = Path.GetFullPath(path_im);
            books.Add(this);
            allids.Add(iD);
            if (t)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karen\Documents\GitHub\BookStore\Project\MainDatas\MainDatas\data\booksdata.mdf;Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string command = "Insert into Allbooks(Id,Name,Writer,Introduction,Price,PDF,Image) values( " + ID + " ,'" + Name_ketab.Trim() + "','" + Name_nevisande.Trim() + "','" + Tozih_ketab.Trim() + "'," + Gheymat + ",'" + path.Trim() + "','" + path_image.Trim() + "') ";
                SqlCommand doo = new SqlCommand(command, connection);
                doo.BeginExecuteNonQuery();
                connection.Close();
            }
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
                books[i].tedad_emtiyaz_dahandegan=books[i].Voters.Count;
            }
        }
    }
    
}