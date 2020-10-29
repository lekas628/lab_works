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
            
            long ellapledTicks = DateTime.Now.Ticks;
            

            MyStack stack = new MyStack(_len);
            for(int i = 0; i < sh_ar.Length; i++)
                stack.Add(i);

            //stack = MyStack.quicksort(stack);
            stack.quicksort();


            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;

            bool success = is_stack_sorted(stack.GetCopy());

            return ( _len, ellapledTicks, success);
        }

        static int[] get_shuffled_array(int _len, int _max, int _min = 0)
        {
            int[] shuffled_input = new int[_len];
            Random randNum = new Random();
            for (int i = 0; i < shuffled_input.Length; i++)
            {
                shuffled_input[i] = randNum.Next(_min, _max);
            }
            return shuffled_input;
        }

        static bool is_stack_sorted(MyStack st)
        {
            int tmp = st.Pop();
            while (!st.IsEmpty())
            {
                if (tmp >= st.Peek())
                {
                    tmp = st.Pop();
                    continue;
                }

                else
                    return false;
            }
            return true;
        }
    }
}
