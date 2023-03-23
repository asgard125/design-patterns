using System;
using System.Collections.Generic;

namespace ConsoleApp1
{

    public interface Iterator<T>
    {
        bool MoveNext();
    }

    public class ArrayIterator<T> : Iterator<T>
    {
        ArrayList<T> arr;
        int pos = -1;

        public ArrayIterator(ArrayList<T> arr)
        {
            this.arr = arr;
        }
        
        public bool MoveNext()
        {
            pos++;
            return pos < arr.Size();
        }

        public T Current => arr.get(pos);

    }



    public interface List<T>
    {
        public void add(T elem);
        public void put(T elem, int pos);
        public void remove(int pos);
        public int find(T elem);
        public T get(int index);

    }


    public class ArrayList<T> : List<T>
    {

        private T[] arr;
        private int DEFAULT_ARRAYLIST_SIZE = 5;
        private int size;
        private int capacity;


        public ArrayList()
        {
            this.arr = new T[DEFAULT_ARRAYLIST_SIZE];
            this.size = 0;
            this.capacity = DEFAULT_ARRAYLIST_SIZE;
        }

        public ArrayList(int n)
        {
            this.arr = new T[n];
            this.size = 0;
            this.capacity = n;
        }

        private void extend_array()
        {
            if (this.size == this.capacity)
            {
                this.capacity = this.capacity + this.DEFAULT_ARRAYLIST_SIZE;
                T[] new_arr = new T[this.capacity];
                for (int i = 0; i < this.size; i++)
                {
                    new_arr[i] = this.arr[i];
                }
                this.arr = new_arr;
            }
        }


        public void add(T elem)
        {
            this.extend_array();
            arr[size] = elem;
            this.size++;
        }

        public void put(T elem, int pos)
        {
            if (pos > this.size - 1)
            {
                Console.WriteLine("Указанная позиция превышает размер массива");
            }
            else
            {
                this.arr[pos] = elem;
            }
        }

        public void remove(int pos)
        {
            if (pos > this.size - 1)
            {
                Console.WriteLine("Указанная позиция превышает размер массива");
            }
            else
            {
                T[] new_arr = new T[this.capacity];
                int elem_pos = 0;
                this.size--;
                for (int i = 0; i < this.size; i++)
                {
                    if (i == pos)
                    {
                        elem_pos++;
                    }
                    new_arr[i] = this.arr[elem_pos];
                    elem_pos++;
           
                }
                this.arr = new_arr;
            }
        }

        public int find(T elem)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.arr[i].Equals(elem))
                {
                    return i;
                }
            }

            return -1;

        }

        public T get(int ind)
        {
            return this.arr[ind];
        }

        public int Size()
        {
            return this.size;
        }

        public ArrayIterator<T> GetEnumerator()
        {
            return new ArrayIterator<T>(this);
        }
    }





    class Program
    {
        public static void Main(String[] args)
        {
            ArrayList<int> arr = new ArrayList<int>();
            arr.add(5);
            arr.add(4);
            arr.add(3);
            arr.add(2);
            arr.add(1);
            arr.add(15);
            Console.WriteLine(arr.find(15));
            Console.WriteLine(arr.get(3));
            arr.put(40, 3);
            Console.WriteLine(arr.get(3));
            arr.remove(1);
            Console.WriteLine(arr.get(3));
            Console.WriteLine("-----------------------------------");
            foreach (int i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}

