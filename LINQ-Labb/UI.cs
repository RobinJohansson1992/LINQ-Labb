using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ_Labb
{
    internal class UI
    {
        public static void RunProgram()
        {
            bool run = true;
            while (run)
            {

                Console.Clear();
                Console.WriteLine("1. Hämta alla produkter i kategorin Electronics och sortera dem efter pris (högst först)");
                Console.WriteLine("2. Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter");
                Console.WriteLine("3. Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden");
                Console.WriteLine("4. Hitta de 3 mest sålda produkterna baserat på OrderDetail-data");
                Console.WriteLine("5. Lista alla kategorier och antalet produkter i varje kategori");
                Console.WriteLine("6. Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr");
                Console.WriteLine("7. Avsluta");
                int menuLength = 7;

                int userInput;
                while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > menuLength)
                {
                    Console.WriteLine("Du måste ange ett nummer från listan.");
                }

                switch (userInput)
                {
                    case 1:
                        Queries.SortedElectronicProducts();
                        break;
                    case 2:
                        Queries.FilteredSuppliers();
                        break;
                    case 3:
                        Queries.TotalOrderAmount();
                        break;
                    case 4:
                        Queries.MostSoldProducts();
                        break;
                    case 5:
                        Queries.CategoryProductCount();
                        break;
                    case 6:
                        Queries.PrintOrdersWithDetails();
                        break;
                    case 7:
                        run = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
