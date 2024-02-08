using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BSUIR_Lab_6
{
    delegate void GreetMessage();
    delegate void ManyAlerts();
    delegate string CnangeName(string name);

    internal class Bot
    {
        public string name;
        public string surname;
        private int age;
        public string email;

        private GreetMessage greetMessage;

        public int Age{
            get { return age; }
            set {
                if (value >= 0 && value < 99) age = value;
                else throw new Exception("Incorrect age.");
                }
        }

        public Bot()
        {
            name = string.Empty;
            surname = string.Empty;
            age = 0;
            email = string.Empty;
        }

        public Bot(string name, string surname, int age, string email): this()
        {
            this.name = name;
            this.surname = surname;
            Age = age;
            this.email = email;
        }

        public void Greet()
        {
            // Вызывает делегат
            greetMessage?.Invoke();
        }

        public void AddGreet(GreetMessage delGreet)
        {
            // Заполняет делегат
            greetMessage = delGreet;
        }

        public void DeleteGreet()
        {
            // Очищает делегат.
            greetMessage -= greetMessage;
        }

        public override string ToString()
        {
            string info = $"Name: {name}\nSurname: {surname}\nAge: {Age}\nEmail: {email}\n";
            return info;
        }
    }

    class BotAlerts : Bot
    {
        public ManyAlerts DelsAlerts { get; private set; }

        private CnangeName delCnahgeName;


        public BotAlerts(string name, string surname, int age, string email) :base(name, surname, age, email) { }
        
        public void AddAlerts( params ManyAlerts[] alerts)
        {
            // Добавляет делегаты
            foreach (ManyAlerts alert in alerts) { DelsAlerts += alert; }
        }

        public void DeleteAlerts(params ManyAlerts[] alerts)
        {
            // Удаляет делегаты
            foreach (ManyAlerts alert in alerts) { DelsAlerts -= alert;}
        }

        public void InstallCnangeNameDel(CnangeName _del)
        {
            delCnahgeName = _del;  
        }

        public void DeleteChangeNameDel()
        {
            delCnahgeName = null;
        }

        public void ChangeName(string new_name)
        {
            if (delCnahgeName == null) { name = new_name; }
            else { name = delCnahgeName(new_name); }
        }

        public void SayAlerts()
        {
            DelsAlerts?.Invoke();
        }

        public static void CompareAlerts(BotAlerts user1, BotAlerts user2 )
        {
            if (user1.DelsAlerts == user2.DelsAlerts)
            {
                Console.WriteLine($"У пользователя {user1.name} и пользователя {user2.name} оповещния одинаковы");
            }
            else
            {
                Console.WriteLine($"У пользователя {user1.name} и пользователя {user2.name} разные оповещния");
            }
        }
    }

    class BotEventFire: BotAlerts
    {
        private int criticalSmoke = 10;

        public delegate void Fire();
        private event Fire? _OnFire;
        public event Fire? OnFire

        {
            add { _OnFire += value; }
            remove { _OnFire -= value; }
        }
        public BotEventFire(string name, string surname, int age, string email, int criticalSmokeLevel = 10) : base(name, surname, age, email)
        {
            if (criticalSmokeLevel > 0) { criticalSmoke = criticalSmokeLevel; }
        }

        public void StartFireAlarm(int percentSmoke)
        {
            if (percentSmoke > criticalSmoke && _OnFire != null) { _OnFire(); }
        }
    }    
}

