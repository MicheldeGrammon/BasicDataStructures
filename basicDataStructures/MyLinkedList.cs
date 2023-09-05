using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicDataStructures
{
    internal class MyLinkedList<T> : IEnumerable<T>, IMyLinkedList<T>
    {
        private MyNode<T> head;
        private MyNode<T> tail;
        private int СountElements { get; set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= СountElements)
                {
                    throw new IndexOutOfRangeException();
                }
                var result = head;
                for (var i = 0; i < index; i++)
                {
                    result = result.Next;
                }

                return result.Data;
            }
            set
            {
                if (index < 0 || index >= СountElements)
                {
                    throw new IndexOutOfRangeException();
                }
                var result = head;
                for (var i = 0; i < index; i++)
                {
                    result = result.Next;
                }

                result.Data = value;
            }
        }

        public void Add(T data)
        {
            MyNode<T> node = new MyNode<T>(data);
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            СountElements++;
        }

        public int Count() => СountElements;

        public bool IsEmpty() => СountElements == 0;

        public void Clear()
        {
            head = null;
            tail = null;
            СountElements = 0;
        }

        public bool Remove(T data)
        {
            MyNode<T> current = head;
            MyNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == head)
                    {
                        head = head.Next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    else if (current == tail)
                    {
                        tail = previous;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    СountElements--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }


            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            MyNode<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }

}
