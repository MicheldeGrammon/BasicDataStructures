using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace basicDataStructures
{
    internal static class ExtensionMyStructures
    {
        //the Sort method uses the quicksort algorithm
        public static void Sort<T>(this MyLinkedList<T> linkedList, int startIndex, int endIndex) where T : IComparable
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var pivot = startIndex - 1;
            for (var i = startIndex; i < endIndex; i++)
            {
                if (linkedList[i].CompareTo(linkedList[endIndex]) == -1)
                {
                    pivot++;
                    Swap(linkedList, pivot, i);
                }
            }
            pivot++;
            Swap(linkedList, pivot, endIndex);
            Sort(linkedList, startIndex, pivot - 1);
            Sort(linkedList, pivot + 1, endIndex);
        }

        private static void Swap<T>(MyLinkedList<T> linkedList, int i, int j)
        {
            var temp = linkedList[i];
            linkedList[i] = linkedList[j];
            linkedList[j] = temp;
        }

        public static bool IndexSerch<T>(this MyLinkedList<T> linkedList, T target, out int index) where T : IComparable
        {
            index = -1;
            for (int i = 0; i < linkedList.Count(); i++)
            {
                if (linkedList[i].CompareTo(target) == 0)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public static bool IndexSerch<T>(this MyStack<T> stack, T target, out int index) where T : IComparable
        {
            index = -1;
            for (int i = 0; i < stack.Count(); i++)
            {
                if (stack[i].CompareTo(target) == 0)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public static bool IndexSerch<T>(this MyQueue<T> queue, T target, out int index) where T : IComparable
        {
            index = -1;
            for (int i = 0; i < queue.Count(); i++)
            {
                if (queue[i].CompareTo(target) == 0)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
    }
}
