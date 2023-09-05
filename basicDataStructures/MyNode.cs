using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicDataStructures
{
    internal class MyNode<T>
    {
        public MyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public MyNode<T>? Next { get; set; }
    }
}
