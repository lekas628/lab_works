using System;
using MyArrayFolder;
using System.IO;

namespace Linear_Structures
{
    class Program
    {
        static void Main(string[] args)
        {

            run();

            //int[] shuffled = get_shuffled_array(10, 10);
            //foreach (int i in shuffled)
            //    Console.WriteLine(i);
            //Console.WriteLine("\n");

            //shuffled = get_shuffled_array(10, 10);
            //foreach (int i in shuffled)
            //    Console.WriteLine(i);


            //ms.quicksort(0, ms.TopPointer - 1);
            //ms.WriteUsingPop();

            //foreach (int i in array)
            //    Console.WriteLine(i);


        }

        static void run()
        {
            //int[] testing_lenght = { 10, 50, 100, 500, 1000, 3000, 5000 };
            int[] testing_lenght = { 300, 600, 900, 1200, 1500, 1800, 2100, 2400, 2700, 3000 };

            string pathCsvFile = @"C:\Users\leka6\Documents\code\lab_works\Linear_Structures\log.csv";
            if (!File.Exists(pathCsvFile))
                File.Create(pathCsvFile);

            using (StreamWriter streamWriter = new StreamWriter(pathCsvFile))
            {
                Console.WriteLine($"{"Len",10} {"N_op",25} {"Time (sec)",25} {"success",10}");
                foreach (int size in testing_lenght)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        (int, long, TimeSpan, bool) test = test_stack(size);
                        //Console.WriteLine(test);
                        string line = $"{test.Item1,10} {test.Item2,25} {test.Item3.TotalSeconds,25} {test.Item4,10}";
                        string line_for_csv = $"{test.Item1};{test.Item2};{test.Item3.TotalSeconds};{test.Item4}";
                        Console.WriteLine(line);

                        streamWriter.WriteLine(line_for_csv);
                        streamWriter.Flush();
                    }
                }
            }
        }

        static (int, long, TimeSpan, bool) test_stack(int _len)
        {
            MyStack.N_op = 0;
            int max = _len;
            int[] sh_ar = get_shuffled_array(_len, max);


            //long ellapledTicks = DateTime.Now.Ticks;
            TimeSpan Time1 = DateTime.Now.TimeOfDay;



            MyStack stack = new MyStack(_len);
            for (int i = 0; i < sh_ar.Length; i++)
                stack.Add(sh_ar[i]);


            stack.quicksort(0, stack.TopPointer - 1);


            //ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            TimeSpan Time2 = DateTime.Now.TimeOfDay;
            TimeSpan time_result = Time2 - Time1;

            long N_op = MyStack.N_op;
            bool success = is_stack_sorted(stack.GetCopy());

            return (_len, N_op, time_result, success);
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