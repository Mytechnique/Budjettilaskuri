using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budjettilaskuri
{
    class Program
    {
        static void Main(string[] args)
        {
            Budjetti();
            ReadLine();
        }

        private static void Budjetti()      //Pitäisi olla toimivasti vikasietoinen, pyytää käyttäjältä tiedon uudestaan ellei syöte ole oikein.
                                            //Valitettavasti vähäinen tietoni rajauttaa koodaukseni konsoliohjelmiin.
        {
            int veroprosentti;
            int tulot;
            int menot;
            int saastot;

            WriteLine("Syötä veroprosentti: ");
            if (!int.TryParse(ReadLine(), out veroprosentti))
            {
                do
                {
                    WriteLine("Syöte ei ole kelvollinen. Syötä veroprosentti: ");
                }
                while (!int.TryParse(ReadLine(), out veroprosentti));
            }
            else
            {
                WriteLine($"Veroprosentti on: {veroprosentti}%");
            }

            WriteLine("Syötä bruttotulo: ");
            if (!int.TryParse(ReadLine(), out tulot))
            {
                do
                {
                    WriteLine("Syöte ei ole kelvollinen. Syötä bruttotulo: ");
                }
                while (!int.TryParse(ReadLine(), out tulot));
            }
            else
            {
                WriteLine($"Bruttotulosi on: {tulot}");
            }


            WriteLine("Syötä kulut/kk: ");
            if (!int.TryParse(ReadLine(), out menot))
            {
                do
                {
                    WriteLine("Syöte ei ole kelvollinen. Syötä kulut/kk: ");
                }
                while (!int.TryParse(ReadLine(), out menot));
            }
            else
            {
                WriteLine($"Kuukausittaiset kulusi ovat: {menot}");
            }

            WriteLine("Syötä tavoitesäästö: ");
            if (!int.TryParse(ReadLine(), out saastot))
            {
                do
                {
                    WriteLine("Syöte ei ole kelvollinen. Syötä tavoitesäästö: ");
                }
                while (!int.TryParse(ReadLine(), out saastot));
            }
            else
            {
                WriteLine($"Tavoite on: {saastot}");
            }

        }
    }
}
