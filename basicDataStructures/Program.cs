namespace basicDataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //mini-test
            var myList = new MyLinkedList<int>
            {
                4,
                2,
                1,
                4
            };

            myList.Sort(0,myList.Count()-1);

            foreach (var item in myList) 
            {
                Console.WriteLine(item);
            }
        }
    }
}