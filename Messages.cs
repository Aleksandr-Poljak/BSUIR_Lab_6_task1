using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_6
{  
    // Класс  статических  методов для делегатов.
    internal static class Messages
    {
        public static void SayHello()
        {
            Console.WriteLine("Hello!\n");
        }

        public static void SayGoodMorning()
        {
            Console.WriteLine("Good morning!\n");
        }

        public static void SayGoodEvening()
        {
            Console.WriteLine("Good evening!\n");
        }

        public static void SayGoodNight()
        {
            Console.WriteLine("Good night!\n");
        }

        public static void SayCareful()
        {
            Console.WriteLine("Careful!!\n");
        }
        public static void SayStop() 
        {
            Console.WriteLine("This place is off-limits!!\n");
        }
        
        public static void SayDanger() 
        {
            Console.WriteLine("It can be dangerous here!!\n");
        }

        public static string UpperText(string text)
        {
            return text.ToUpper();
        }
    }
}
