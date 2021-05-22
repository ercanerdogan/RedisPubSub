using StackExchange.Redis;
using System;

namespace redis_subscriber
{
    class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel";
        static void Main(string[] args)
        {
            Console.WriteLine("Listening test-channel");
            var pubsub = connection.GetSubscriber();

            pubsub.Subscribe(Channel, (channel, message) => Console.Write("Message received from test-channel : " + message));
            Console.ReadLine();
        }
    }
}
