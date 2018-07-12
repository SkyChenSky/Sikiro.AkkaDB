using System;
using System.Collections.Concurrent;
using Akka.Actor;
using Akka.Util.Internal;
using Sikiro.AkkaDB.Entity;

namespace Sikiro.AkkaDB.Server
{
    public class ServerActor : ReceiveActor
    {
        private static readonly ConcurrentDictionary<string, object> ConDic = new ConcurrentDictionary<string, object>();

        public ServerActor()
        {
            Receive<string>(msg => msg.Equals("Connect"), msg =>
            {
                Sender.Tell(true, Self);
            });

            Receive<SetMessage>(msg =>
            {
                ConDic.AddOrSet(msg.Key, msg.Value);

                Console.WriteLine($"Set:key:{msg.Key},value:{msg.Value}");
            });

            Receive<GetMessage>(msg =>
            {
                ConDic.TryGetValue(msg.Key, out var value);

                Sender.Tell(value ?? new Failure { Exception = new NullValueException("no data") }, Self);

                Console.WriteLine($"Get:key:{msg.Key},value:{value}");
            });

            Receive<DeleteMessage>(msg =>
            {
                var result = ConDic.TryRemove(msg.Key, out var value);

                Sender.Tell(result, Self);

                Console.WriteLine($"Delete:key:{msg.Key}");
            });

            ReceiveAny(msg =>
            {
                Sender.Tell(new Failure { Exception = new ConfigCenterServerException($"Unknown operation {msg.ToString()}") }, Self);
            });
        }
    }
}
