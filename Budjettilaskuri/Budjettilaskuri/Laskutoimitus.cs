using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetCalculator
{
    class Calculations
    {
        public int _netincome; // gross income - tax
        public int _incomedifference; //net income  - expenses
        public int _plannedsavings;//income difference - planned savings

        public Calculations(int _netincome, int _incomedifference, int _plannedsavings)  //Laajalti ottanut saatavilla olevasta materiaalista mallia.
            //Mahd, että tehnyt väärin/parempia ratkaisuja. Luokkaan laskutoimitusten määritys jotta ne voisi lisätä main metodiin?
        {
            
        }

        public int getnetIncome()
        {

            return _netincome;
        }
        public int getDifference()
        {
            return _incomedifference;
        }
        public int getBudget()
        {
            return _plannedsavings;
        }
    }
}
