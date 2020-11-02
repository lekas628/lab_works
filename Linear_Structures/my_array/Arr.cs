using System;

namespace MyArrayFolder
{
    public class MyStack
    {
        static public long N_op = 0;
        static void reset_N_op() => N_op = 0;


        private int[] array;

        public int TopPointer { get; private set; }
        public int MaxLen { get; private set; }

        public MyStack(int _len)                                // = 10 = 4 + 3(иниц перем) + 3 (выдел памяти и всякое разное)
        {
            array = new int[_len];                              // 2

            MaxLen = _len;                                      // 1
            TopPointer = 0;                                     // 1

            N_op += 7;
        }
        public void Add(int _value)                             // = 3
        {
            if (TopPointer < MaxLen)                            // 1 
            {
                array[TopPointer++] = _value;                   // 2

                N_op += 2;
            }
        }

        public bool IsEmpty()                                   // = 2
        {
            N_op += 3;
            return TopPointer == 0;
        }

        public int Pop()                                        // = 7
        {
            if (!IsEmpty())                                     // 7 = 3 + 4
            {
                N_op += 3;
                return array[--TopPointer];                         // 4
            }
            else
            {
                throw new IndexOutOfRangeException();

            }
        }
        public int Peek()                                       // = 7
        {
            if (!this.IsEmpty())                                // 7
            {
                N_op += 3;
                return array[TopPointer - 1];                       // 4 
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()                                     // = 1
        {
            N_op += 1;
            TopPointer = 0;                                     // 1
        }

        public int GetMaxSize()                                 // = 1
        {
            N_op += 1;
            return MaxLen;                                      // 1
        }
        public int GetTopPointer()                              // = 1
        {
            N_op += 1;
            return TopPointer;                                  // 1
        }

        // используется во время отладки так что даже не считаю
        public MyStack GetCopy()
        {
            MyStack tmp_stack = new MyStack(GetMaxSize());
            while (!IsEmpty())
                tmp_stack.Add(Pop());

            MyStack for_return = new MyStack(GetMaxSize());     // 11
            while (!tmp_stack.IsEmpty())
            {
                for_return.Add(tmp_stack.Peek());
                Add(tmp_stack.Pop());
            }
            return for_return;
        }

        // используется во время отладки так что даже не считаю
        public void WriteUsingPop()
        {
            while (!IsEmpty())
                Console.WriteLine(Pop());
        }

        public int GetElement(int pos)                          // 26n + 20 = 11 + 13n + 8 + 13n + 1
        {
            MyStack tmp_stack = new MyStack(GetTopPointer());   // 11 = 10 + 1
            N_op += 2;

            while (TopPointer != pos + 1)                       // 13n = n раз, где n размер стека, так что (3(проверка) + 10(внутр)) * n     
            {
                N_op += 4;
                tmp_stack.Add(Pop());                               // 10
            }
            int element = Peek();                               // 8 = 7 + 1
            N_op += 2;

            while (!tmp_stack.IsEmpty())                        // 13n 
            {
                N_op += 4;
                Add(tmp_stack.Pop());                               // 3(add) + 7(pop) = 10
            }
            N_op += 1;
            return element;                                     // 1
        }
        public void Swap(int i, int j)                          // = 52n + 49
        {
            if (i > j)                                          // = 5
            {
                N_op += 5;
                int tmp = i;                                    // 2
                i = j;                                          // 1
                j = tmp;                                        // 1
            }

            MyStack tmp_stack_1 = new MyStack(GetMaxSize());    // 11
            MyStack tmp_stack_2 = new MyStack(GetMaxSize());    // 11
            N_op += 4;

            while (TopPointer != j + 1)                          // 13n
            {
                tmp_stack_1.Add(Pop());                             // 10
                N_op += 4;
            }
            int value_1 = Pop();                                // 8
            N_op += 2;

            while (TopPointer != i + 1)                         // 13n
            {
                tmp_stack_2.Add(Pop());                              // 10
                N_op += 4;
            }
            int value_2 = Pop();                                // 8
            N_op += 2;

            Add(value_1);                                       // 3
            N_op += 1;

            while (!tmp_stack_2.IsEmpty())                      // 13n
            {
                Add(tmp_stack_2.Pop());                             // 10
                N_op += 4;

            }
            Add(value_2);                                       // 3
            N_op += 1;

            while (!tmp_stack_1.IsEmpty())                      // 13n
            {
                Add(tmp_stack_1.Pop());                             // 10
                N_op += 4;
            }
        }

        public void quicksort(int LB, int UB)
        {
            int i = LB;                                         // 1
            int j = UB;                                         // 1
            while (i != j)
            {
                /* т.к. i и j сходятся друг к другу по 1, 
                 * крч дописать эту штуку и досчитать потом
                */
                while (i != j)
                {
                    if (GetElement(i) <= GetElement(j))         // 52n + 42 = 26n+20 + 26n+20 + 1 + 1
                    {
                        --j;                                        // 1
                        N_op += 2;
                    }
                    else                                            // 52n + 49
                    {
                        Swap(i, j);                                 // 52n + 49
                        N_op += 2;
                        break;                                      // 1
                    }
                }
                while (i != j)
                {
                    if (GetElement(i) <= GetElement(j))         // 52n + 42
                    {
                        ++i;                                        // 1
                        N_op += 2;
                    }
                    else
                    {
                        Swap(i, j);                                 // 52n + 49
                        N_op += 2;
                        break;                                      // 1
                    }
                }
            }
            if (i - 1 > LB)
            {
                N_op += 2;
                quicksort(LB, i - 1);
            }
            if (j + 1 < UB)
            {
                N_op += 2;
                quicksort(j + 1, UB);
            }
        }
    }
}