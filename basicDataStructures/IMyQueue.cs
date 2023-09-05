namespace basicDataStructures
{
    public interface IMyQueue<T>
    {
        public T this[int index] { get; set; }
        public void Clear();
        public T Dequeue();
        public void Enqueue(T data);
        public T Peek();
        public bool TryDequeue(out T result);
        public bool TryPeek(out T result);
        public int Count();
    }
}
