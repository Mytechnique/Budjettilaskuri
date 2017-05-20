using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Budget();
            ReadLine();
        }

        private static void Budget()      //Should be fault tolerant, asks user input again if incorrect.
        {
            int taxpercent;
            int income;
            int expenses;
            int savings;

            WriteLine("Please insert your tax percent: ");
            if (!int.TryParse(ReadLine(), out taxpercent))
            {
                do
                {
                    WriteLine("Input invalid. Please input your tax percent: ");
                }
                while (!int.TryParse(ReadLine(), out taxpercent));
            }
            else
            {
                WriteLine($"Your tax percent is: {taxpercent}%");
            }

            WriteLine("Please insert gross income: ");
            if (!int.TryParse(ReadLine(), out income))
            {
                do
                {
                    WriteLine("Input invalid. Please input your gross income: ");
                }
                while (!int.TryParse(ReadLine(), out income));
            }
            else
            {
                WriteLine($"Your gross income is: {income}");
            }


            WriteLine("Please insert your monthly expenses: ");
            if (!int.TryParse(ReadLine(), out expenses))
            {
                do
                {
                    WriteLine("Input invalid. Please input your expenses: ");
                }
                while (!int.TryParse(ReadLine(), out expenses));
            }
            else
            {
                WriteLine($"Your monthly expenses are: {expenses}");
            }

            WriteLine("Please insert planned savings: ");
            if (!int.TryParse(ReadLine(), out savings))
            {
                do
                {
                    WriteLine("Input invalid. Please input your planned savings: ");
                }
                while (!int.TryParse(ReadLine(), out savings));
            }
            else
            {
                WriteLine($"Planned savings: {savings}");
            }

        }
    }
}
