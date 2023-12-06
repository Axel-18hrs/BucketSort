
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
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Utilizar el arreglo directamente (números enteros)");
                Console.WriteLine("2. Utilizar el método que genera un vector (números enteros)");
                Console.WriteLine("3. Utilizar el arreglo directamente (números decimales)");
                Console.WriteLine("4. Utilizar el método que genera un vector (números decimales)");
                Console.WriteLine("0. Salir");

                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
                    Console.ReadKey();
                    continue;
                }

                switch (option)
                {
                    case 1:
                        int[] array1 = { 4, 2, 3, 5, 5, 7, 1 };
                        Console.WriteLine("Array antes de ordenar:");
                        PrintArray(array1);
                        BucketSort_int(array1);
                        Console.WriteLine("\nArray después de ordenar:");
                        PrintArray(array1);
                        break;

                    case 2:
                        int[] array2 = GenerarVector();
                        Console.WriteLine("Array antes de ordenar:");
                        PrintArray(array2);
                        BucketSort_int(array2);
                        Console.WriteLine("\nArray después de ordenar:");
                        PrintArray(array2);
                        break;

                    case 3:
                        double[] array3 = { 0.42, 0.33, 0.37, 0.57, 0.40 };
                        Console.WriteLine("Array antes de ordenar:");
                        PrintArray(array3);
                        BucketSort_Double(array3);
                        Console.WriteLine("\nArray después de ordenar:");
                        PrintArray(array3);
                        break;

                    case 4:
                        double[] array4 = GenerarVectorDouble();
                        Console.WriteLine("Array antes de ordenar:");
                        PrintArray(array4);
                        BucketSort_Double(array4);
                        Console.WriteLine("\nArray después de ordenar:");
                        PrintArray(array4);
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija una opción del 0 al 4.");
                        break;
                }
                Console.ReadKey();
            } while (true);
        }

        public static double[] GenerarVectorDouble(int Minon = 0, int Lenght = 10, int values = 5)
        {
            List<double> _List = new List<double>();

            for (int i = Minon; i < Lenght; i++)
            {
                if (i < values)
                {
                    double NewValor = _rand.NextDouble();
                    _List.Add(NewValor);
                }
                else
                {
                    break;
                }
            }
            return _List.ToArray();
        }

        public static int[] GenerarVector(int Minon = 0, int Lenght = 10, int values = 5)
        {
            List<int> _List = new List<int>();

            for (int i = Minon; i < Lenght; i++)
            {
                if (i < values)
                {
                    int NewValor = _rand.Next(Minon, Lenght + 1);
                    if (_List.Contains(NewValor))
                    {
                        i--;
                        continue;
                    }
                    _List.Add(NewValor);
                }
                else
                {
                    break;
                }
            }
            return _List.ToArray();
        }

        private static void PrintArray(double[] doubles)
        {
            foreach (double item in doubles)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void BucketSort_Double(double[] array)
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

            // Imprimir el estado de los buckets después de la inserción
            PrintBucketState(buckets);

            // Ordenar los elementos de cada cubo
            for (int i = 0; i < array.Length; i++)
            {
                buckets[i].Sort();
            }

            // Imprimir el estado de los buckets después de la ordenación
            PrintBucketState(buckets);

            // Obtener los elementos ordenados
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
            PrintBucketState(buckets);

            // Ordena cada cubo individualmente
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();
            }
            PrintBucketState(buckets);

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
