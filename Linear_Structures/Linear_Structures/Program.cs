using System;
using MyArrayFolder;


namespace Linear_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // чтение загатовленного массива из файла
            // 5, 10 или 100 чисел 
            int len = 100;
            string file = $@"..\..\..\..\shuffledarr{len}.txt";
            string[] prepared_array = System.IO.File.ReadAllText(file).Split(", ");
            int[] shuffled_input = new int[len];
            for (int i = 0; i < len; i++)
                shuffled_input[i] = Convert.ToInt32(prepared_array[i]);


            
            MyStack stack = new MyStack(len);
            for (int i = 0; i < len; i++)
                stack.Add(shuffled_input[i]);

            stack = MyStack.quicksort(stack);

            foreach (int i in stack.ARR)
                Console.WriteLine(i);

            //}
            //static void PrintArray(int[] arr)
            //{
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        Console.WriteLine($"{i} elem of arr is {arr[i]}");
            //    }
            //    Console.WriteLine('\n');
        }



    }
}
