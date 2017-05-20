using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budjettilaskuri
{
    class Laskutoimitus
    {
        public int _nettotulo; //brutto - vero
        public int _palkanerotus; //nettotulo - menot
        public int _hsaastot;//palkanerotus - haluttu säästö

        public Laskutoimitus(int _nettotulo, int _palkanerotus, int _hsaastot)  //Laajalti ottanut saatavilla olevasta materiaalista mallia.
            //Mahd, että tehnyt väärin/parempia ratkaisuja. Luokkaan laskutoimitusten määritys jotta ne voisi lisätä main metodiin?
        {
            
        }

        public int getNetto()
        {

            return _nettotulo;
        }
        public int getErotus()
        {
            return _palkanerotus;
        }
        public int getSaastot()
        {
            return _hsaastot;
        }
    }
}
