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



        public List<Airbnb> GetDataFromFile()
        {
            List<Airbnb> collection = new List<Airbnb>();
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

            reader.Close();
            return collection;
        }

        public void WriteResultsToFile(List<Result> l)
        {
            StreamWriter writer = new StreamWriter(@"analysis.csv");
            writer.WriteLine("attempt, sample, bubble, selection, insertion, quick, merge, mixed");

            foreach (Result r in l)
            {
                writer.WriteLine(
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                    r.attempt,
                    r.sample,
                    r.bubble,
                    r.selection,
                    r.insertion,
                    r.quick,
                    r.merge,
                    r.mixed
                );
            }
            writer.Close();
        }

        public long SortList(List<Airbnb> l, int size, string type)
        {
            l = l.Take(size).ToList();
            Stopwatch stopwatch = new Stopwatch();

            switch (type)
            {
                case "bubble":
                    stopwatch.Start();
                    Sort.Bubble(l);
                    stopwatch.Stop();
                    break;
                case "selection":
                    stopwatch.Start();
                    Sort.Selection(l);
                    stopwatch.Stop();
                    break;
                case "insertion":
                    stopwatch.Start();
                    Sort.Insertion(l);
                    stopwatch.Stop();
                    break;
                case "quick":
                    stopwatch.Start();
                    Sort.Quick(l, 0, l.Count - 1);
                    stopwatch.Stop();
                    break;
                case "merge":
                    stopwatch.Start();
                    Sort.Merge(l, 0, l.Count - 1);
                    stopwatch.Stop();
                    break;
                case "mixed":
                    stopwatch.Start();
                    Sort.Mixed(l);
                    stopwatch.Stop();
                    break;
            }
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
