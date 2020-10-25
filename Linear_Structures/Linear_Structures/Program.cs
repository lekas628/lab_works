using System;
using MyArrayFolder;


namespace Linear_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // чтение загатовленного массива из файла
            // 10 или 100 чисел 
            int len = 10;
            string file = $@"..\..\..\..\shuffledarr{len}.txt";
            string[] prepared_array = System.IO.File.ReadAllText(file).Split(", ");
            int[] shuffled_input = new int[len];
            for (int i = 0; i < len; i++)
                shuffled_input[i] = Convert.ToInt32(prepared_array[i]);


            
            MyArray array = new MyArray(len);
            array.add(55);
            array.add(3);

            Console.WriteLine(array.pop());
            Console.WriteLine(array.pop());
            Console.WriteLine(array.isEmpty());

        }
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{i} elem of arr is {arr[i]}");
            }
            Console.WriteLine('\n');
        }
    }
}
