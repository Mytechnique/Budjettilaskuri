using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace BudgetCalculator
{
    class Calculations
    {
        private double _netincome; // gross income - tax
        private double _incomedifference; //net income  - expenses
        private double _plannedsavings; //income difference - planned savings
        private double _yearlysavings;//savings x 12
        private double _yearlytax;//income * (taxpercent & 100) * 12

        public Calculations(double netincome, double incomedifference, double plannedsavings, double yearlytax, double yearlysavings)
        {
            _netincome = netincome;
            _incomedifference = incomedifference;
            _plannedsavings = plannedsavings;
            _yearlysavings = yearlysavings;
            _yearlytax = yearlytax;

            double taxpercent;
            double income;
            double expenses;
            double savings;

            taxpercent = double.Parse(ReadLine());
            income = double.Parse(ReadLine());
            expenses = double.Parse(ReadLine());
            savings = double.Parse(ReadLine());

            yearlytax = income * (taxpercent % 100) * 12;
            incomedifference = netincome - expenses;
            plannedsavings = incomedifference - savings;
            yearlysavings = plannedsavings * 12;
        }
        public void getNetincome(double netincome)
        {
            _netincome = netincome;
        }
        public double getIncomedifference(double incomedifference)
        {
            return _incomedifference;
        }
        public double getPlannedsavings(double plannedsavings)
        {
            return _plannedsavings;
        }
        public double getYearlytax(double yearlytax)
        {
            return _yearlytax;
        }
        public double getYearlysavings(double yearlysavings)
        {
            return _yearlysavings;
        }
    }
}
