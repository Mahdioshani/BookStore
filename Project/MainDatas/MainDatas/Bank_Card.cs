using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MainDatas
{
    public class Bank_Card
    {
        public static ObservableCollection<Bank_Card> cards = new ObservableCollection<Bank_Card>();
        public static ObservableCollection<int> ids = new ObservableCollection<int>();
        public int ID { get; set; }
    }
}
