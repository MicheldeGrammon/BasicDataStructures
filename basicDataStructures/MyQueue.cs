using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicDataStructures
{
    internal class MyQueue<T> : IEnumerable<T>, IMyQueue<T>
    {
        private MyNode<T> head;
        private MyNode<T> tail;
        private int СountElements { get; set; } = 0;

        public void Clear()
        {
            head = null;
            tail = null;
            СountElements = 0;
        }

        public T Dequeue()
        {
            var result = head.Data;
            head = head.Next;
            СountElements--;
            return result;
        }

        public void Enqueue(T data)
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

        public T Peek()
        {
            if (СountElements <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this[0];
        }

        public bool TryDequeue(out T result)
        {
            if (СountElements <= 0)
            {
                result = default;
                return false;
            }
            result = head.Data;
            СountElements--;
            head = head.Next;

            return true;
        }

        public bool TryPeek(out T result)
        {
            if (СountElements <= 0)
            {
                result = default;
                return false;
            }
            result = head.Data;
            return true;
        }

        public int Count() => СountElements;

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
