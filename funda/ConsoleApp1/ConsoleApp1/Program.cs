using System;
namespace ConsoleApp1
{
   public class Program
    {
        static void Main(string[] args)
        {
            /* if (args.Length == 0)
                 Console.WriteLine("Hello World");
                 for (int i = 0; i < args.Length; i++)
                 {
                     Console.WriteLine("Hi " + args[i]);
                 }  */
            string name = "";
            Console.WriteLine("your name");
            name = Console.ReadLine();
            Console.WriteLine("How many hours you sleep?");
            int hoursOfSleep = int.Parse(Console.ReadLine());
            Console.WriteLine("Hello "+name);
            if(hoursOfSleep > 8)
                Console.WriteLine("Lazy");
            else
                Console.WriteLine("Good");
            Console.ReadKey();
        }
    }
}
