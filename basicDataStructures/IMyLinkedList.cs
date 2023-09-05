namespace basicDataStructures
{
    public interface IMyLinkedList<T>
    {
        public T this[int index] { get; set; }
        public void Add(T data);
        public bool Remove(T data);
        public void Clear();
        public int Count();
    }
}
