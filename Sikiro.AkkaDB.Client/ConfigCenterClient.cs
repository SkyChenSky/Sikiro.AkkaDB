using System;
using Akka.Actor;
using Akka.Configuration;
using Sikiro.AkkaDB.Entity;

namespace Sikiro.AkkaDB.Client
{
    public class ConfigCenterClient
    {
        private readonly ActorSystem _system = ActorSystem.Create("SikiroConfigCenterClient", ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = remote
    }
}
"));
        private readonly ActorSelection _remoteDb;

        public bool IsConnect { get; }

        public ConfigCenterClient(string remoteAddress)
        {
            _remoteDb = _system.ActorSelection($"akka.tcp://SikiroConfigCenterServer@{remoteAddress}/user/Server");

            var connectResult = _remoteDb.Ask<bool>("Connect");

            if (connectResult.IsCompletedSuccessfully)
            {
                IsConnect = true;
                Console.WriteLine("Connect:it connected");
            }
        }

        public void Set(string key, object value)
        {
            _remoteDb.Tell(new SetMessage { Key = key, Value = value });
        }

        public TResult Get<TResult>(string key)
        {
            var result = _remoteDb.Ask(new GetMessage { Key = key }).Result;
            if ((result as Failure)?.Exception is NullValueException)
                return default(TResult);

            return (TResult)result;
        }

        public void Remove(string key)
        {
            _remoteDb.Tell(new DeleteMessage { Key = key });
        }
    }
}
