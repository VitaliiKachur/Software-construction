using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Authenticator
    {
        private static Authenticator _instance;

        private static readonly object _lock = new object();

        private Authenticator() { }

        public static Authenticator Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Authenticator();
                    }
                    return _instance;
                }
            }
        }

        public void Authenticate()
        {
            Console.WriteLine("Аутентифікація користувача...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var thread1 = new System.Threading.Thread(() =>
            {
                var auth = Authenticator.Instance;
                auth.Authenticate();
            });

            var thread2 = new System.Threading.Thread(() =>
            {
                var auth = Authenticator.Instance;
                auth.Authenticate();
            });

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            var auth1 = Authenticator.Instance;
            var auth2 = Authenticator.Instance;

            Console.WriteLine(ReferenceEquals(auth1, auth2) ? "Існує тільки один екземпляр!" : "Різні екземпляри!");
        }
    }
}
