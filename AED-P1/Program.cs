using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_P1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sorting Algorithms Analysis\n");
            while (true)
            {
                Console.Write("Type........: ");
                string type = Console.ReadLine();
                Console.Write("Sample Size.: ");
                int size = int.Parse(Console.ReadLine());

                Airbnb airbnb = new Airbnb();
                List<Airbnb> roomList = airbnb.getDataFromFile();

                if (size > roomList.Count)
                {
                    Console.WriteLine("Assuming....: {0} (data file rows count).", roomList.Count);
                    size = roomList.Count;
                }

                Console.Write("Calculating..");
                long timeElapsed = airbnb.SortList(roomList, size, type);
                if (timeElapsed < 0)
                {
                    Console.WriteLine("Invalid Type\n");
                    continue;
                }
                ShowResult(timeElapsed);
            }
        }

        static void ShowResult(long time)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

            Console.WriteLine("Elapsed Time: {0} ms\n", time);
        }
    }
}
