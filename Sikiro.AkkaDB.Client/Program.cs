using System;

namespace Sikiro.AkkaDB.Client
{

    class Program
    {
        static void Main(string[] args)
        {
            var configCenterClient = new AkkaDBClient("localhost:1218");

            while (true)
            {
                Console.WriteLine("please input command:1 for set;2 for get;3 for delete");
                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        {
                            Console.WriteLine("please input key");
                            var key = Console.ReadLine();

                            Console.WriteLine("please input value");
                            var value = Console.ReadLine();

                            configCenterClient.Set(key, value);
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("please input key");
                            var key = Console.ReadLine();

                            var value = configCenterClient.Get<string>(key);

                            Console.WriteLine($"value:{value}");
                        }
                        break;
                    case "3":
                        {
                            Console.WriteLine("please input key");
                            var key = Console.ReadLine();

                            configCenterClient.Remove(key);
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
