using System;

namespace MyArrayFolder
{
    public class MyStack
    {
        private int[] array;

        public int TopPointer { get; private set; }
        public int MaxLen { get; private set; }

        // потом убрать
        public int[] ARR
        {
            get { return array; }
            set { array = value; }
        }

        public MyStack(int _len = 100)
        {
            array = new int[_len];

            MaxLen = _len;
            TopPointer = 0;
        }

        public void Add(int _value)
        {
            if (TopPointer < MaxLen)
            {
                array[TopPointer++] = _value;
            }

        }

        public int Pop() => !IsEmpty() ? array[--TopPointer] : throw new IndexOutOfRangeException();
        public int Peek() => !this.IsEmpty() ? array[TopPointer - 1] : throw new IndexOutOfRangeException();
        public bool IsEmpty() => (TopPointer == 0);
        public void Clear() => TopPointer = 0;
        public int GetSize() => MaxLen;
        public int GetTopPointer() => TopPointer;





        public static MyStack quicksort(MyStack ms) //, bool isReversed)
        {
            if (ms.IsEmpty())
                return ms;

            int pivot = ms.Pop();

            MyStack l_ms = new MyStack(ms.MaxLen);
            MyStack r_ms = new MyStack(ms.MaxLen);
            MyStack result_ms = new MyStack(ms.MaxLen);

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
                if (tmp < pivot)
                    l_ms.Add(tmp);
                else
                    r_ms.Add(tmp);
            }

            MyStack l_ms_sorted = quicksort(l_ms);
            MyStack r_ms_sorted = quicksort(r_ms);


            while (!l_ms_sorted.IsEmpty())
                result_ms.Add(l_ms_sorted.Pop());

            result_ms.Add(pivot);

            while (!r_ms_sorted.IsEmpty())
                result_ms.Add(r_ms_sorted.Pop());



            return result_ms;
        }
    }

}
