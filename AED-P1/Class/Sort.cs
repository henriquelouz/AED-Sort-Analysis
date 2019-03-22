using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_P1
{
    static class Sort
    {
        public static void Bubble(List<Airbnb> l)
        {
            for (int i = 0; i < l.Count - 1; i++)
                for (int j = 0; j < l.Count - i - 1; j++)
                    if (l[j].roomID > l[j + 1].roomID)
                    {
                        Airbnb aux = l[j];
                        l[j] = l[j + 1];
                        l[j + 1] = aux;
                    }
        }

        public static void Selection(List<Airbnb> l)
        {
            for (int i = 0; i < l.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < l.Count; j++)
                    if (l[j].roomID < l[min].roomID)
                        min = j;

                Airbnb aux = l[i];
                l[i] = l[min];
                l[min] = aux;
            }
        }

        public static void Insertion(List<Airbnb> l)
        {
            for (int i = 1; i < l.Count; i++)
            {
                int j = i;
                while (j > 0 && l[j].roomID < l[j - 1].roomID)
                {
                    Airbnb aux = l[j];
                    l[j] = l[j - 1];
                    l[j - 1] = aux;
                    j--;
                }
            }
        }

        public static void Quick(List<Airbnb> l, int left, int right)
        {
            int i = left,
                j = right,
                pivot = l[(left + right) / 2].roomID;

            while (i <= j)
            {
                while (l[i].roomID < pivot && i < right) i++;
                while (l[j].roomID > pivot && j > left) j--;

                if (i <= j)
                {
                    Airbnb aux = l[i];
                    l[i] = l[j];
                    l[j] = aux;
                    i++;
                    j--;
                }
            }

            if (j > left)
                Quick(l, left, j);

            if (i < right)
                Quick(l, i, right);
        }

        public static void Merge(List<Airbnb> l, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                Merge(l, start, middle);
                Merge(l, middle + 1, end);
                merge(l, start, middle, end);
            }
        }

        private static void merge(List<Airbnb> l, int start, int middle, int end)
        {
            int n1 = middle - start + 1;
            int n2 = end - middle;

            List<Airbnb> l1 = new List<Airbnb>();
            List<Airbnb> l2 = new List<Airbnb>();

            int i, j;
            for (i = 0; i < n1; i++)
                l1.Add(l[start + i]);
            for (j = 0; j < n2; j++)
                l2.Add(l[middle + j + 1]);

            l1.Add(new Airbnb() { roomID = Int32.MaxValue });
            l2.Add(new Airbnb() { roomID = Int32.MaxValue });

            i = j = 0;

            for (int k = start; k <= end; k++)
                if (l1[i].roomID <= l2[j].roomID)
                    l[k] = l1[i++];
                else
                    l[k] = l2[j++];
        }

        public static void Mixed(List<Airbnb> l)
        {
            int half = l.Count / 2 + l.Count % 2;
            List<Airbnb> l1 = l.GetRange(0, half);
            List<Airbnb> l2 = l.GetRange(half, l.Count / 2);

            for (int i = 0; i < l1.Count - 1; i++)
                for (int j = 0; j < l1.Count - i - 1; j++)
                    if (l1[j].roomID > l1[j + 1].roomID)
                    {
                        Airbnb aux = l1[j];
                        l1[j] = l1[j + 1];
                        l1[j + 1] = aux;
                    }

            for (int i = 0; i < l2.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < l2.Count; j++)
                    if (l2[j].roomID < l2[min].roomID)
                        min = j;

                Airbnb aux = l2[i];
                l2[i] = l2[min];
                l2[min] = aux;
            }

            l1.Add(new Airbnb() { roomID = Int32.MaxValue });
            l2.Add(new Airbnb() { roomID = Int32.MaxValue });

            int i1 = 0, i2 = 0;
            for (int k = 0; k <= l.Count-1; k++)
                if (l1[i1].roomID <= l2[i2].roomID)
                    l[k] = l1[i1++];
                else
                    l[k] = l2[i2++];
        }
    }
}
