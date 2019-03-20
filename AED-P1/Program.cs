using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_P1
{
    class Program
    {
        private static string[] types = new string[] { "bubble", "selection", "insertion", "quick", "merge", "mixed" };

        static void Main(string[] args)
        {
            Console.WriteLine("Sorting Algorithms Analysis\n");

            Airbnb airbnb = new Airbnb();
            List<Airbnb> roomList = airbnb.GetDataFromFile();
            List<Result> results = new List<Result>();

            for (int i = 2000; i <= 128000; i *= 2)
            {
                for (int j = 1; j <= 5; j++)
                {
                    results.Add(new Result() { attempt = j, sample = i });
                    foreach (string type in types)
                    {
                        long time = airbnb.SortList(roomList, i, type);
                        results[results.Count - 1].GetType().GetProperty(type).SetValue(results[results.Count - 1], time);

                        Console.WriteLine("Attempt: {0}", j);
                        Console.WriteLine("Sample.: {0}", i);
                        Console.WriteLine("Type...: {0}", type);
                        Console.WriteLine("Time...: {0}\n", time);
                    }
                }
            }

            airbnb.WriteResultsToFile(results);
            Console.WriteLine("Done! Check out the results in the csv generated file.");
        }
    }
}
