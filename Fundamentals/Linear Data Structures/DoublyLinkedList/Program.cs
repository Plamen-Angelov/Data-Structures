using System;

namespace Problem02.DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(12);
            list.AddLast(64);
            list.AddFirst(118);
            list.AddLast(464);
            Console.WriteLine(list.Count);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
