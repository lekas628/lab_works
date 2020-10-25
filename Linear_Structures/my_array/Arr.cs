using System;

namespace MyArrayFolder
{
    public class MyArray
    {
        // главный массив
        private int[] array;
        
        // указывает на следующее свободное место в массиве
        public int TopPointer { get; private set; }
        // максимальный размер массива
        public int MaxLen { get; set; }


        // потом убрать
        public int[] ARR
        {
            get { return array; }
            set { array = value; }
        }




        public MyArray(int _len = 100)
        {
            array = new int[_len];
            foreach (int i in array)
                array[i] = 0;
            
            MaxLen = _len;
            TopPointer = 0;
        }
        public void add(int _value)
        {
            if (TopPointer < MaxLen)
            {
                array[TopPointer++] = _value;
            }
        }
        
        //public int pop()
        //{
        //    if (!isEmpty())
        //    {
        //        return array[--TopPointer];

        //    }
        //    else
        //        throw new IndexOutOfRangeException();
        //}

        public int pop() => !isEmpty() ? array[--TopPointer] : throw new IndexOutOfRangeException();

        public bool isEmpty() => (TopPointer == 0);
        

    }

}
