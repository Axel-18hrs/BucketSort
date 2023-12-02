
using System.Diagnostics;

namespace BucketSort
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] array = { 4, 2, 3, 5, 5, 7, 1 };
            Console.WriteLine("Array antes de ordenar:");
            PrintArray(array);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BucketSort_int(array);

            stopwatch.Stop();

            Console.WriteLine("\nArray despues de ordenar:");
            PrintArray(array);
            Console.WriteLine("\nEl proceso a tardado: " + stopwatch.Elapsed);
            Console.ReadKey();
            Console.Clear();


            double[] array_2 = { 0.42, 0.33, 0.37, 0.57, 0.40 };
            Console.WriteLine("Array antes de ordenar:");
            PrintArray(array_2);

            stopwatch.Start();

            BucketSort_Double(array_2);

            stopwatch.Stop();

            Console.WriteLine("\nArray despues de ordenar:");
            PrintArray(array_2);
            Console.WriteLine("\nEl proceso a tardado: " + stopwatch.Elapsed);
            Console.ReadKey();
            Console.Clear(); 
        }

        private static void PrintArray(double[] doubles)
        {
            foreach (double item in doubles)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static double[] BucketSort_Double(double[] array)
        {
            // Crear buckets vacíos
            List<double>[] buckets = new List<double>[array.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<double>();
            }

            // Insertar elementos en sus respectivos buckets
            foreach (double element in array)
            {
                buckets[(int)(element * array.Length)].Add(element);
            }

            // Ordenar los elementos de cada cubo
            for (int i = 0; i < array.Length; i++)
            {
                buckets[i].Sort();
            }

            // Obtener los elementos ordenados
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    array[k] = buckets[i][j];
                    k++;
                }
            }

            return array;
        }


        public static void BucketSort_int(int[] array)
        {

            // Encuentra el valor máximo en el array
            int maxVal = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                    maxVal = array[i];
            }
            // Crea una lista de buckets vacíos
            List<int>[] buckets = new List<int>[maxVal + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            // Distribuye los elementos en los buckets
            for (int i = 0; i < array.Length; i++)
            {
                buckets[array[i]].Add(array[i]);
            }

            // Ordena cada cubo individualmente
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();
            }

            // Concatena los elementos ordenados de cada cubo
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                foreach (var item in buckets[i])
                {
                    array[index++] = item;
                }
            }
        }
        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }
}
