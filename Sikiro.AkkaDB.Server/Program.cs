using System;
using Akka.Actor;
using Akka.Configuration;

namespace Sikiro.AkkaDB.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
             akka{  
                  actor {
                     provider = remote
                 }
                 remote {
                     dot-netty.tcp {
                        port = 1218
                        hostname = localhost
                     }
                 }
             }
             ");

            using (var system = ActorSystem.Create("SikiroConfigCenterServer", config))
            {
                system.ActorOf<ServerActor>("Server");

                Console.ReadLine();
            }
        }
    }
}
