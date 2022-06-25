using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MainDatas
{
    public class Admin
    {
        public static int mojoodi_froshgah;
        public ObservableCollection<Bank_Card> bank_Cards = new ObservableCollection<Bank_Card>();
        public string Password;

    }
}
