using System;

namespace AbstractFactoryPattern
{
    interface ILaptop
    {
        void ShowDetails();
    }

    interface INetbook
    {
        void ShowDetails();
    }

    interface IEBook
    {
        void ShowDetails();
    }

    interface ISmartphone
    {
        void ShowDetails();
    }

    class IProneLaptop : ILaptop
    {
        public void ShowDetails() { Console.WriteLine("IProne Laptop: High-end performance, Retina Display"); }
    }

    class IProneNetbook : INetbook
    {
        public void ShowDetails() { Console.WriteLine("IProne Netbook: Lightweight, long battery life"); }
    }

    class IProneEBook : IEBook
    {
        public void ShowDetails() { Console.WriteLine("IProne EBook: E-ink display, Apple Books support"); }
    }

    class IProneSmartphone : ISmartphone
    {
        public void ShowDetails() { Console.WriteLine("IProne Smartphone: iOS, Face ID, 5G support"); }
    }

    class KiaomiLaptop : ILaptop
    {
        public void ShowDetails() { Console.WriteLine("Kiaomi Laptop: Affordable, good battery, high resolution"); }
    }

    class KiaomiNetbook : INetbook
    {
        public void ShowDetails() { Console.WriteLine("Kiaomi Netbook: Budget-friendly, compact size"); }
    }

    class KiaomiEBook : IEBook
    {
        public void ShowDetails() { Console.WriteLine("Kiaomi EBook: Low-cost, Android-based reading app"); }
    }

    class KiaomiSmartphone : ISmartphone
    {
        public void ShowDetails() { Console.WriteLine("Kiaomi Smartphone: Android OS, large screen, good cameras"); }
    }
    class BalaxyLaptop : ILaptop
    {
        public void ShowDetails() { Console.WriteLine("Balaxy Laptop: High-performance, AMOLED screen"); }
    }

    class BalaxyNetbook : INetbook
    {
        public void ShowDetails() { Console.WriteLine("Balaxy Netbook: Slim design, productivity-focused"); }
    }

    class BalaxyEBook : IEBook
    {
        public void ShowDetails() { Console.WriteLine("Balaxy EBook: Smart features, built-in store"); }
    }

    class BalaxySmartphone : ISmartphone
    {
        public void ShowDetails() { Console.WriteLine("Balaxy Smartphone: Foldable screen, flagship performance"); }
    }

    interface ITechFactory
    {
        ILaptop CreateLaptop();
        INetbook CreateNetbook();
        IEBook CreateEBook();
        ISmartphone CreateSmartphone();
    }

    class IProneFactory : ITechFactory
    {
        public ILaptop CreateLaptop() { return new IProneLaptop(); }
        public INetbook CreateNetbook() { return new IProneNetbook(); }
        public IEBook CreateEBook() { return new IProneEBook(); }
        public ISmartphone CreateSmartphone() { return new IProneSmartphone(); }
    }

    class KiaomiFactory : ITechFactory
    {
        public ILaptop CreateLaptop() { return new KiaomiLaptop(); }
        public INetbook CreateNetbook() { return new KiaomiNetbook(); }
        public IEBook CreateEBook() { return new KiaomiEBook(); }
        public ISmartphone CreateSmartphone() { return new KiaomiSmartphone(); }
    }

    class BalaxyFactory : ITechFactory
    {
        public ILaptop CreateLaptop() { return new BalaxyLaptop(); }
        public INetbook CreateNetbook() { return new BalaxyNetbook(); }
        public IEBook CreateEBook() { return new BalaxyEBook(); }
        public ISmartphone CreateSmartphone() { return new BalaxySmartphone(); }
    }

    class Client
    {
        private readonly ILaptop _laptop;
        private readonly INetbook _netbook;
        private readonly IEBook _eBook;
        private readonly ISmartphone _smartphone;

        public Client(ITechFactory factory)
        {
            _laptop = factory.CreateLaptop();
            _netbook = factory.CreateNetbook();
            _eBook = factory.CreateEBook();
            _smartphone = factory.CreateSmartphone();
        }

        public void ShowTechDetails()
        {
            _laptop.ShowDetails();
            _netbook.ShowDetails();
            _eBook.ShowDetails();
            _smartphone.ShowDetails();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\nОберіть бренд для перегляду пристроїв:");
                Console.WriteLine("1 - IProne");
                Console.WriteLine("2 - Kiaomi");
                Console.WriteLine("3 - Balaxy");
                Console.WriteLine("0 - Вийти");

                string choice = Console.ReadLine();
                ITechFactory factory = null;

                switch (choice)
                {
                    case "1":
                        factory = new IProneFactory();
                        break;
                    case "2":
                        factory = new KiaomiFactory();
                        break;
                    case "3":
                        factory = new BalaxyFactory();
                        break;
                    case "0":
                        Console.WriteLine("Дякуємо за використання нашої системи!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        continue;
                }

                Client client = new Client(factory);
                client.ShowTechDetails();
                Console.WriteLine("\n-------------------------------------\n");
            }
        }
    }
}
