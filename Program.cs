
using System;
using System.Diagnostics;

namespace BucketSort
{
    internal class Program
    {
        private static Random _rand = new Random();

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Use the array directly (integer numbers)");
                Console.WriteLine("2. Use the method that generates an array (integer numbers)");
                Console.WriteLine("3. Use the array directly (decimal numbers)");
                Console.WriteLine("4. Use the method that generates an array (decimal numbers)");
                Console.WriteLine("0. Exit");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ReadKey();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        int[] array1 = { 4, 2, 3, 5, 5, 7, 1 };
                        Console.WriteLine("Array before sorting: [" + string.Join(", ", array1) + "]");
                        DateTime startTime = DateTime.Now;
                        BucketSort_int(array1);
                        Console.WriteLine("\nArray after sorting: [" + string.Join(", ", array1) + "]");
                        Console.WriteLine("Time: " + (DateTime.Now - startTime));
                        break;

                    case 2:
                        int[] array2 = GenerateIntArray();
                        Console.WriteLine("Array before sorting: [" + string.Join(", ", array2) + "]");
                        DateTime startTime_ = DateTime.Now;
                        BucketSort_int(array2);
                        Console.WriteLine("\nArray after sorting: [" + string.Join(", ", array2) + "]");
                        Console.WriteLine("Time: " + (DateTime.Now - startTime_));
                        break;

                    case 3:
                        double[] array3 = { 0.42, 0.33, 0.37, 0.57, 0.40 };
                        Console.WriteLine("Array before sorting: [" + string.Join(", ", array3) + "]");
                        DateTime startTim = DateTime.Now;
                        BucketSort_Double(array3);
                        Console.WriteLine("\nArray after sorting: [" + string.Join(", ", array3) + "]");
                        Console.WriteLine("Time: " + (DateTime.Now - startTim));
                        break;

                    case 4:
                        double[] array4 = GenerateDoubleArray();
                        Console.WriteLine("Array before sorting: [" + string.Join(", ", array4) + "]");
                        DateTime s_tartTim = DateTime.Now;
                        BucketSort_Double(array4);
                        Console.WriteLine("\nArray after sorting: [" + string.Join(", ", array4) + "]");
                        Console.WriteLine("Time: " + (DateTime.Now - s_tartTim));
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose an option from 0 to 4.");
                        break;
                }
                Console.ReadKey();
            } while (true);
        }

        public static double[] GenerateDoubleArray(int Min = 0, int Length = 10, int Values = 5)
        {
            List<double> list = new List<double>();

            for (int i = Min; i < Length; i++)
            {
                if (i < Values)
                {
                    double newValue = _rand.NextDouble();
                    list.Add(newValue);
                }
                else
                {
                    break;
                }
            }
            return list.ToArray();
        }

        public static int[] GenerateIntArray(int Min = 0, int Length = 10, int Values = 5)
        {
            List<int> list = new List<int>();

            for (int i = Min; i < Length; i++)
            {
                if (i < Values)
                {
                    int newValue = _rand.Next(Min, Length + 1);
                    if (list.Contains(newValue))
                    {
                        i--;
                        continue;
                    }
                    list.Add(newValue);
                }
                else
                {
                    break;
                }
            }
            return list.ToArray();
        }

        static void BucketSort_Double(double[] array)
        {
            // Create empty buckets
            List<double>[] buckets = new List<double>[array.Length];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<double>();
            }

            // Insert elements into their respective buckets
            foreach (double element in array)
            {
                buckets[(int)(element * array.Length)].Add(element);
            }

            // Print the state of the buckets after insertion
            PrintBucketState(buckets);

            // Sort the elements in each bucket
            for (int i = 0; i < array.Length; i++)
            {
                buckets[i].Sort();
            }

            // Print the state of the buckets after sorting
            PrintBucketState(buckets);

            // Get the sorted elements
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (var item in buckets[i])
                {
                    array[k++] = item;
                }
            }
        }

        static void PrintBucketState(List<int>[] buckets)
        {
            Console.WriteLine("Current state of buckets:");
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"Bucket {i}: ");
                foreach (var item in buckets[i])
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintBucketState(List<double>[] buckets)
        {
            Console.WriteLine("Current state of buckets:");
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.Write($"Bucket {i}: ");
                foreach (var item in buckets[i])
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void BucketSort_int(int[] array)
        {
            // Find the maximum value in the array
            int maxVal = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                    maxVal = array[i];
            }
            // Create a list of empty buckets
            List<int>[] buckets = new List<int>[maxVal + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            // Distribute elements into the buckets
            for (int i = 0; i < array.Length; i++)
            {
                buckets[array[i]].Add(array[i]);
            }
            PrintBucketState(buckets);

            // Sort each bucket individually
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();
            }
            PrintBucketState(buckets);

            // Concatenate the sorted elements from each bucket
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                foreach (var item in buckets[i])
                {
                    array[index++] = item;
                }
            }
        }
    }
}
