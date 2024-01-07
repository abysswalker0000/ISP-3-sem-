using lab1_Kaakevich_253504.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Kaakevich_253504.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T>
    {
        private class Node
        {
            public T Info { get; set; }
            public Node Next { get; set; }

            public Node(T info)
            {
                Info = info;
                Next = null;
            }
        }

        private Node head;
        private Node current;
        private int count;

        public MyCustomCollection()
        {
            head = null;
            current = null;
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node.Info;
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                node.Info = value;
            }
        }

        public void Reset()
        {
            current = head;
        }

        public void Next()
        {
            if (current != null)
            {
                current = current.Next;
            }
        }

        public T Current()
        {
            if (current != null)
            {
                return current.Info;
            }
            else
            {
                throw new InvalidOperationException("Error");
            }
        }

        public int Count { get { return count; } }

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
                current = head;
            }
            else
            {
                Node lastNode = head;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                lastNode.Next = newNode;
            }
            count++;
        }

        public void Remove(T item)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Info.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }
                    count--;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public T RemoveCurrent()
        {
            T data = current.Info;
            Remove(data);
            return data;
        }
    }
}
