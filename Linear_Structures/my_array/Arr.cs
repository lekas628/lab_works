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


        public void Reverse()
        {
            MyStack tmp1 = new MyStack(GetSize());
            MyStack tmp2 = new MyStack(GetSize());
            while (!this.IsEmpty())
                tmp1.Add(this.Pop());
            while (!tmp1.IsEmpty())
                tmp2.Add(tmp1.Pop());
            while (!tmp2.IsEmpty())
                this.Add(tmp2.Pop());
        }


        public static MyStack quicksort(MyStack ms)
        {
            if (ms.IsEmpty())
                return ms;
            if (ms.TopPointer == 1)
                return ms;

            int pivot = ms.Pop();

            MyStack l_ms = new MyStack(ms.MaxLen);
            MyStack r_ms = new MyStack(ms.MaxLen);



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

            r_ms_sorted.Reverse();

            while (!r_ms_sorted.IsEmpty())
                l_ms_sorted.Add(r_ms_sorted.Pop());

            return l_ms_sorted;
        }

    }
}
