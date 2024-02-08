using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_6
{
    internal static  class FireHandler1
    {
        public static void WarningFire()
        {
            // Для подписки на событие OnFire экземпляра класса  BotEventFire
            Console.WriteLine("Произошел пожар. Срочно покинтье помещение");
        }
    }
}
