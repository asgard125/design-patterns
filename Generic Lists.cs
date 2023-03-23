using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    interface List<T>
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
                for (int i = 0; i < this.size; i++)
                {
                    if (i == pos)
                    {
                        i++;
                    }
                    new_arr[i] = this.arr[i];
           
                }
                this.arr = new_arr;
                this.size--;
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
    }


    public class LinkedList<T> : List<T>
    {

        private class Node<Y>
        {
            public Node<Y> prev;
            public Node<Y> next;
            public Y value;
        }
        private Node<T> node;
        private int size;


        public LinkedList()
        {
            this.node = null;
            this.size = 0;
        }


        public void add(T elem)
        {
            Node<T> new_node = new Node<T>();
            new_node.value = elem;
            new_node.next = null;
            new_node.prev = this.node;
            if (size == 0) { 

                new_node.prev = null;
                this.node = new_node;
            }
            else
            {
                Node<T> node = this.node;
                for(int i = 1;  i < this.size; i++)
                {
                    node = node.next;
                }
                new_node.prev = node;
                node.next = new_node;
            }
            size++;
            
        }

        public void put(T elem, int pos)
        {
            pos = pos + 1;
            if (pos > this.size - 1)
            {
                Console.WriteLine("Указанная позиция превышает размер массива");
            }
            else
            {
                Node<T> node = this.node;
                for (int i = 1; i < pos; i++)
                {
                   node = node.next;
                }
                node.value = elem;
            }
        }

        public void remove(int pos)
        {
            pos = pos + 1;
            if (pos > this.size)
            {
                Console.WriteLine("Указанная позиция превышает размер массива");
            }
            else
            {
                Node<T> node = this.node;
                for (int i = 1; i < pos; i++)
                {
                    node = node.next; 
                }
                node.prev.next = node.next;
            }
            size--;
        }

        public int find(T elem)
        {
            Node<T> node = this.node;
            for (int i = 1; i < this.size; i++)
            {
                if (node.value.Equals(elem))
                {
                    return i - 1;
                }
                node = node.next;
            }
            return -1;

        }

        public T get(int ind)
        {
            ind = ind + 1;
            Node<T> node = this.node;
            for (int i = 1; i < ind; i++)
            {
                node = node.next;
            }
            return node.value;
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
            Console.WriteLine("--------------------------------------------");
            LinkedList<int> list = new LinkedList<int>();
            list.add(10);
            list.add(20);
            list.add(30);
            list.add(777);
            list.add(50);
            Console.WriteLine(list.find(20));
            Console.WriteLine(list.get(3));
            list.remove(2);
            Console.WriteLine(list.get(3));
            list.put(100, 2);
            Console.WriteLine(list.get(2));
        }
    }
}

