using System.Text;

namespace task0
{
    internal class Program
    {

        /*
         * Рассчитать номера для выполнения 5 заданий согласно своего варианта по журналу по формуле:
         * ((N^3 + K^2) % 210) + 1
         */
        public static void Main(string[] args)
        {
            int k = 21;
            Console.WriteLine("Job numbers: ");
            for (int n = 1; n <= 5; n++)
            {
                Console.WriteLine(((Math.Pow(n, 3) + Math.Pow(k, 2)) % 210) + 1);
            }
            task23();
            Console.WriteLine("\n------------------------------------");
            task30();
            Console.WriteLine("\n------------------------------------");
            task49();
            Console.WriteLine("\n------------------------------------");
            task86();
            Console.WriteLine("\n------------------------------------");
            task147();
        }
        /*
         * В массиве хранится информация о численности книг в каждом из 35 разделов библиотеки. 
         * Выяснить, верно ли, что общее число книг в библиотеке есть шестизначное число.
         */
        public static void task23()
        {
            Console.WriteLine("Task 23.");
            int[] libliary = fillArray(35);
            int result = 0;
            foreach (var item in libliary)
            {
                result += item;
            }
            Console.WriteLine("Total number of books in the library: " + result);
            if (result.ToString().Length == 6)
            {
                Console.WriteLine("The number of books in the library is six figures.");
            }
            else
            {
                Console.WriteLine("The number of books in the library is not six figures.");
            }
        }

        /*
         * Дана последовательность натуральных чисел а1, а2, ..., an. 
         * Создать массив из четных чисел этой последовательности. 
         * Если таких чисел нет, то вывести сообщение об этом факте.
         */
        public static void task30()
        {
            Console.WriteLine("Task 30.\n" + "Enter array length: ");
            int length = inputNumber();

            int[] numbersArray = fillArray(length); ;
            int[] evenNumbersArray= sortArray(numbersArray) ;
            if (evenNumbersArray[0] != 0)
            {
                printArray(evenNumbersArray);
            }
            else
            {
                Console.WriteLine("There are no even numbers.");
            }

        }

        /*
         * Задана последовательность N вещественных чисел. Вычислить значение выражения.
         */
        public static void task49()
        {
            Console.WriteLine("Task 49.\n" + "Enter the number of numbers in the sequence:");
            int length = inputNumber(), result = 1;
            int[] numbersArray = fillArray(length);

            foreach (var item in numbersArray)
            {
                result *= item;
            }
            if (result < 0)
            {
                result *= -1;
            }

            Console.WriteLine("Calculation result: " + Math.Pow(result, 1.0/length));
        }

        /*
         * Дана последовательность вещественных чисел, оканчивающаяся числом 10 000. 
         * Количество чисел в последовательности не меньше двух.
         * Определить, является ли последовательность упорядоченной по возрастанию. 
         * В случае отрицательного ответа определить порядковый номер первого числа, нарушающего такую упорядоченность.
        */
        public static void task86()
        {
            Console.WriteLine("Task 86.");
            int[] numbersArray = fillArray(2, 10000);
            int temp = 2, count = 0;
            foreach (var item in numbersArray)
            {
                if (item > temp)
                {
                    count++;
                    temp = item;
                }
                else
                {
                    Console.WriteLine("A number that violates ascending order: " + count);
                    break;
                }
            }
            if (count == numbersArray.Length)
            {
                Console.WriteLine("The array is sorted in ascending order.");
            }
        }

        /*
         * Дан массив целых чисел. 
         * Найти в этом массиве минимальный элемент m и максимальный элемент М. 
         * Получить в порядке возрастания все целые числа из интервала (m; М), которые не входят в данный массив.
         */
        public static void task147()
        {
            Console.WriteLine("Task 147.\n" + "Enter array length: ");
            int length = inputNumber();
            int[] array = fillArray(length);

            int min = array.Min(), max = array.Max();

            bool foundNumbers = false;

            Console.WriteLine("Numbers not in the array in ascending order: ");
            for (int i = min + 1; i < max; i++)
            {
                if (!array.Contains(i))
                {
                    Console.Write(i + " ");
                    foundNumbers = true;
                }
            }
            if (!foundNumbers)
            {
                Console.WriteLine("No integers found in the specified range.");
            }

        } 

        /*
         * Сортирует массив, оставляя только четные числа.
         */
        public static int[] sortArray(int[] array)
        {
            int[] evenNumbersArray = new int[array.Length];
            int count = 0 ;
            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    evenNumbersArray[count++] = item;
                }
            }
            return evenNumbersArray;
        }

        /*
         * Выводит весь массив кроме нулей в нем.
         */
        public static void printArray(int[] evenNumbersArray)
        {
            string output = "";

            foreach (var item in evenNumbersArray)
            {
                if (item != 0)
                {
                    output += item + ", ";
                }
            }

            if (output.Length > 0)
            {
                output = output.Remove(output.Length - 2);
            }

            Console.Write(output);
        }

        /*
         * Заполняет массив случайными числами от 0 до 10000.
         */
        public static int[] fillArray(int length)
        {
            Random rand = new Random();
            int[] array= new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(0, 10000);
            }
            return array;
        }
        
        /*
         * Заполняет массив случайного размера, случайными числами. 
         * Последнее число массива всегда 10000.
         */
        public static int[] fillArray(int minNumber, int maxNumber)
        {
            Random rand = new Random();
            int[] array = new int[rand.Next(minNumber, maxNumber)];
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    array[i] = 10000;
                }
                else
                {
                    array[i] = rand.Next(minNumber, maxNumber);
                }
            }
            return array;
        }

        /*
         * Метод для ввода числа с клавиатуры.
         * Число не может быть отрицательным и в числе не должны присутствовать сторонние символы.
         */
        public static int inputNumber()
        {
            string input = "";
            int number = 0;
            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    number = int.Parse(input);
                    if (number > 0)
                    {
                        return number;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }
    }
}