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


            
            MyStack stack = new MyStack(len);
            for (int i = 0; i < len; i++)
                stack.Add(shuffled_input[i]);

            stack = quicksort(stack);

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


        static MyStack quicksort(MyStack ms) //, bool isReversed)
        {
            if (ms.IsEmpty())
                return ms;

            int pivot = ms.Pop();

            MyStack l_ms = new MyStack(ms.MaxLen);
            MyStack r_ms = new MyStack(ms.MaxLen);

            //while(!ms.IsEmpty())
            //{
            //    int tmp = ms.Pop();
            //    if (tmp <= pivot)
            //    {
            //        if (!isReversed)
            //            l_ms.add(tmp);
            //        else
            //            r_ms.add(tmp);
            //    }
            //    else
            //    {
            //        if (!isReversed)
            //            r_ms.add(tmp);
            //        else
            //            l_ms.add(tmp);
            //    }
            //    isReversed = !isReversed;
            //}


            while (!ms.IsEmpty())
            {
                int tmp = ms.Pop();
                if (tmp <= pivot)
                    l_ms.Add(tmp);
                else
                    r_ms.Add(tmp);
            }
            
            MyStack l_ms_sorted = quicksort(l_ms);
            MyStack r_ms_sorted = quicksort(r_ms);

            l_ms_sorted.Add(pivot);
            while (!r_ms_sorted.IsEmpty())
                l_ms_sorted.Add(r_ms_sorted.Pop());

            return l_ms_sorted;
        }
    }
}
