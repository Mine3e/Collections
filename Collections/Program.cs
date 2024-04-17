using System;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CustomList<int> customList = new CustomList<int>();
            customList.Add(5);
            customList.Add(10);
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            customList.Remove(5);
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            customList.Add(50);
            customList.Add(45);
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            Console.WriteLine(customList.Find(predicate => predicate == 45));
            Console.WriteLine("----");
            customList.Reverse();
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----");
            customList.Sort();
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
