using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicDataStructures
{
    internal class MyStack<T> : IEnumerable<T>, IMyStack<T>
    {
        private MyNode<T> head;
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

        public T Peek()
        {
            if (СountElements <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this[0];
        }

        public T Pop()
        {
            if (СountElements <= 0)
            {
                throw new IndexOutOfRangeException();
            }
            var result = this[0];
            head = head.Next;
            СountElements--;
            return result;
        }

        public void Push(T data)
        {
            MyNode<T> node = new MyNode<T>(data);
            node.Next = head;
            head = node;
            СountElements++;
        }

        public bool TryPeek(out T result)
        {
            if (СountElements <= 0)
            {
                result = default;
                return false;
            }
            result = this[0];
            return true;
        }

        public bool TryPop(out T result)
        {
            if (СountElements <= 0)
            {
                result = default;
                return false;
            }
            result = this[0];
            head = head.Next;
            СountElements--;
            return true;
        }

        public void Clear()
        {
            СountElements = 0;
            head = null;
        }

        public int Count() => СountElements;

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
