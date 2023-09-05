namespace basicDataStructures
{
    public interface IMyStack<T>
    {
        public T this[int index] { get; set; }
        public void Push(T data);
        public T Pop();
        public T Peek();
        public void Clear();
        public bool TryPeek(out T result);
        public bool TryPop(out T result);
        public int Count();
    }
}
