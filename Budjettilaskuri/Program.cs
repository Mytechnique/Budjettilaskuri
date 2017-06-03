using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Budget();
            ReadLine();
        }

        private static void Budget()
        {
            double taxpercent;
            double income;
            double expenses;
            double savings;
            

            WriteLine("Please insert your tax percent: ");
            if (!double.TryParse(ReadLine(), out taxpercent))
            {
                do
                {
                    WriteLine("Input invalid. Please input your tax percent: ");
                }
                while (!double.TryParse(ReadLine(), out taxpercent));
            }
            WriteLine($"Your tax percent is: {taxpercent}%");


            WriteLine("Please insert gross income: ");
            if (!double.TryParse(ReadLine(), out income))
            {
                do
                {
                    WriteLine("Input invalid. Please input your gross income: ");
                }
                while (!double.TryParse(ReadLine(), out income));
            }
            WriteLine($"Your gross income is: {income}");


            WriteLine("Please insert your monthly expenses: ");
            if (!double.TryParse(ReadLine(), out expenses))
            {
                do
                {
                    WriteLine("Input invalid. Please input your expenses: ");
                }
                while (!double.TryParse(ReadLine(), out expenses));
            }
            WriteLine($"Your monthly expenses are: {expenses}");

            WriteLine("Please insert planned savings: ");
            if (!double.TryParse(ReadLine(), out savings))
            {
                do
                {
                    WriteLine("Input invalid. Please input your planned savings: ");
                }
                while (!double.TryParse(ReadLine(), out savings));
            }
            WriteLine($"Planned savings: {savings}");

            double netincome =  income - (((float)taxpercent / 100.0));
            double incomedifference = netincome - expenses;



            WriteLine($"Net income:{Math.Round(netincome,2)} \nIncome after expenses:{Math.Round(incomedifference, 2)}\n Monthly savings:{savings}\n Yearly savings:{savings * 12}\n Monthly tax:{income * (taxpercent / 100.0)}\n Yearly tax:{income * (taxpercent / 100.0) * 12}");
        }
    }
}
