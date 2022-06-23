using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MainDatas
{
    public class VIP
    {
        public int ID { get; set; }
        public static ObservableCollection<int> ids = new ObservableCollection<int>();
       public static ObservableCollection<VIP> vips = new ObservableCollection<VIP>();
        public ObservableCollection<Book> Book_daroon_VIP = new ObservableCollection<Book>();
        public float Geymat { get; set; }
        public int zaman_be_rooz { get; set; }

        public VIP(int id,ObservableCollection<Book> book_daroon_VIP, float geymat, int zaman_be_rooz)
        {
            if (ids.Contains(id))
                throw new Exception("This Id had already token");
            ID = id;
            ids.Add(id);
            Book_daroon_VIP = book_daroon_VIP;
            Geymat = geymat;
            this.zaman_be_rooz = zaman_be_rooz;
            vips.Add(this);
        }
    }
}
