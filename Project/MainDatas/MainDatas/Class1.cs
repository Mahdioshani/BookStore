using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MainDatas
{
    public class Cart
    {
        public ObservableCollection<Book> Books = new ObservableCollection<Book>();
        public int Geymat_nahaee;
    }
}
