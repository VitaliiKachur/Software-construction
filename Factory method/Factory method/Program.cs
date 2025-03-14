using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    abstract class Subscription
    {
        protected double MonthlyFee;
        protected int MinPeriod;
        protected List<string> Channels;
        protected List<string> Features;

        public abstract void ShowDetails();
    }

    class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            MonthlyFee = 399.99;
            MinPeriod = 6;
            Channels = new List<string> { "Новини", "Спорт", "Розваги" };
            Features = new List<string> { "HD Трансляція" };
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Домашня підписка: {MonthlyFee} грн/міс, Мінімальний період: {MinPeriod} міс.");
            Console.WriteLine("Канали: " + string.Join(", ", Channels));
            Console.WriteLine("Особливості: " + string.Join(", ", Features));
        }
    }

    class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            MonthlyFee = 299.99;
            MinPeriod = 3;
            Channels = new List<string> { "Discovery", "National Geographic", "Science Channel" };
            Features = new List<string> { "Без реклами" };
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Освітня підписка: {MonthlyFee} грн/міс, Мінімальний період: {MinPeriod} міс.");
            Console.WriteLine("Канали: " + string.Join(", ", Channels));
            Console.WriteLine("Особливості: " + string.Join(", ", Features));
        }
    }

    class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            MonthlyFee = 799.99;
            MinPeriod = 12;
            Channels = new List<string> { "HBO", "Netflix", "Disney+" };
            Features = new List<string> { "4K Трансляція", "Перегляд на декількох пристроях" };
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Преміум підписка: {MonthlyFee} грн/міс, Мінімальний період: {MinPeriod} міс.");
            Console.WriteLine("Канали: " + string.Join(", ", Channels));
            Console.WriteLine("Особливості: " + string.Join(", ", Features));
        }
    }

    interface ISubscriptionFactory
    {
        Subscription CreateSubscription();
    }

    class WebSite : ISubscriptionFactory
    {
        public Subscription CreateSubscription() => new DomesticSubscription();
    }

    class MobileApp : ISubscriptionFactory
    {
        public Subscription CreateSubscription() => new EducationalSubscription();
    }

    class ManagerCall : ISubscriptionFactory
    {
        public Subscription CreateSubscription() => new PremiumSubscription();
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("Оберіть спосіб оформлення підписки:");
                Console.WriteLine("1 - Через сайт");
                Console.WriteLine("2 - Через мобільний додаток");
                Console.WriteLine("3 - Через менеджера");
                Console.WriteLine("0 - Вийти");

                string choice = Console.ReadLine();
                ISubscriptionFactory factory;

                switch (choice)
                {
                    case "1":
                        factory = new WebSite();
                        break;
                    case "2":
                        factory = new MobileApp();
                        break;
                    case "3":
                        factory = new ManagerCall();
                        break;
                    case "0":
                        Console.WriteLine("Дякуємо за використання нашої системи!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        continue;
                }

                Subscription subscription = factory.CreateSubscription();
                subscription.ShowDetails();
                Console.WriteLine("\n----------------------\n");
            }
        }
    }
}
