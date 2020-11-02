using System;
using System.Collections.Generic;
using MyArrayFolder;


namespace Linear_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testing_lenght = {10, 50, 100, 500, 1000, 5000};

            foreach(int size in testing_lenght)
            {
                for (int i = 0; i < 10; i++)
                {
                    (int, long, bool) test = test_my_stack(size);
                    Console.WriteLine(test);
                }
            }
        }

        static (int, long, bool) test_my_stack(int _len)
        {
            int max = _len;
            int[] sh_ar = get_shuffled_array(_len, max);
            
            MyStack stack = new MyStack(len);
            for (int i = 0; i < len; i++)
                stack.Add(shuffled_input[i]);

            stack = quicksort(stack);

            MyStack stack = new MyStack(_len);
            for(int i = 0; i < sh_ar.Length; i++)
                stack.Add(i);

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
