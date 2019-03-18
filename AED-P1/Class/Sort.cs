using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_P1
{
    static class Sort
    {
        public static void Bubble(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
                for (int j = 0; j < v.Length - i - 1; j++)
                    if (v[j] > v[j + 1])
                        swap(ref v[j], ref v[j + 1]);
        }

        public static void Selection(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
            {
                int smaller = i;

                for (int j = i + 1; j < v.Length; j++)
                    if (v[j] < v[smaller])
                        smaller = j;

                swap(ref v[smaller], ref v[i]);
            }
        }

        public static void Insertion(int[] v)
        {
            for (int i = 1; i < v.Length; i++)
            {
                int j = i;
                while (j > 0 && v[j] < v[j - 1])
                {
                    swap(ref v[j], ref v[j - 1]);
                    j--;
                }
            }
        }

        public static void Merge(int[] v, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                Merge(v, start, middle);
                Merge(v, middle + 1, end);
                merge(v, start, middle + 1, end);
            }
        }

        private static void merge(int[] v, int start, int middle, int end)
        {
            int[] aux = new int[v.Length];

            int lEnd = (middle - 1);
            int curr = start;

            while ((start <= lEnd) && (middle <= end))
            {
                if (v[start] <= v[middle])
                    aux[curr++] = v[start++];
                else
                    aux[curr++] = v[middle++];
            }

            while (start <= lEnd)
                aux[curr++] = v[start++];

            while (middle <= end)
                aux[curr++] = v[middle++];

            int num = (end - start + 1);

            for (int i = 0; i < num; i++)
            {
                v[end] = aux[end];
                end--;
            }
        }

        public static void Quick(int[] v, int left, int right)
        {
            int i = left,
                j = right,
                pivot = v[(left + right) / 2];

            while (i <= j)
            {
                while (v[i] < pivot && i < right) i++;
                while (v[j] > pivot && j > left) j--;

                if (i <= j)
                {
                    swap(ref v[i], ref v[j]);
                    i++;
                    j--;
                }
            }

            if (j > left)
                Quick(v, left, j);

            if (i < right)
                Quick(v, i, right);
        }

        public static void Mixed(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
                for (int j = 0; j < v.Length - i - 1; j++)
                    if (v[j] < v[j + 1])
                        swap(ref v[j], ref v[j + 1]);

            for (int i = 0; i < v.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < v.Length; j++)
                    if (v[j] < v[min])
                        min = j;

                swap(ref v[min], ref v[i]);
            }
        }

        private static void swap(ref int x, ref int y)
        {
            int aux = x;
            x = y;
            y = aux;
        }
    }
}
