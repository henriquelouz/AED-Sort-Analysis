using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AED_P1
{
    class Airbnb
    {
        public int roomID { get; set; }
        public int hostID { get; set; }
        public string roomType { get; set; }
        public string contry { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public int reviews { get; set; }
        public float overallSatisfaction { get; set; }
        public int accommodates { get; set; }
        public float bedrooms { get; set; }
        public double price { get; set; }
        public string propertyType { get; set; }

        public List<Airbnb> getDataFromFile()
        {
            List<Airbnb> collection  = new List<Airbnb>();
            StreamReader reader = new StreamReader(@"dados_airbnb.txt");
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string[] values = reader.ReadLine().Split('\t');

                Airbnb row = new Airbnb();
                row.roomID = int.Parse(values[0]);
                row.hostID = int.Parse(values[1]);
                row.roomType = values[2];
                row.contry = values[3];
                row.city = values[4];
                row.neighborhood = values[5];
                row.reviews = int.Parse(values[6]);
                row.overallSatisfaction = float.Parse(values[7]);
                row.accommodates = int.Parse(values[8]);
                row.bedrooms = float.Parse(values[9]);
                row.price = double.Parse(values[10]);
                row.propertyType = values[11];

                collection.Add(row);
            }
            return collection;
        }

        public long SortList(List<Airbnb> l, int size, string type)
        {
            int[] roomIDs = new int[size];
            int i = 0;

            foreach (Airbnb row in l.Take(size))
            {
                roomIDs[i] = row.roomID;
                i++;
            }

            Stopwatch stopwatch = new Stopwatch();

            switch (type)
            {
                case "bubble":
                    stopwatch.Start();
                    Sort.Bubble(roomIDs);
                    stopwatch.Stop();
                    break;
                case "selection":
                    stopwatch.Start();
                    Sort.Selection(roomIDs);
                    stopwatch.Stop();
                    break;
                case "insertion":
                    stopwatch.Start();
                    Sort.Insertion(roomIDs);
                    stopwatch.Stop();
                    break;
                case "quick":
                    stopwatch.Start();
                    Sort.Quick(roomIDs, 0, roomIDs.Length - 1);
                    stopwatch.Stop();
                    break;
                case "merge":
                    stopwatch.Start();
                    Sort.Merge(roomIDs, 0, roomIDs.Length - 1);
                    stopwatch.Stop();
                    break;
                case "mixed":
                    stopwatch.Start();
                    Sort.Mixed(roomIDs);
                    stopwatch.Stop();
                    break;
                default:
                    return -1;
            }

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
