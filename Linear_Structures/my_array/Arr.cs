using System;

namespace MyArrayFolder
{
    public class MyStack
    {
        private int[] array;

        public int TopPointer { get; private set; }
        public int MaxLen { get; private set; }

        public MyStack(int _len)
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

   
    }
}
