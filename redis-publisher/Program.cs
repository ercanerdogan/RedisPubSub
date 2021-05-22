using StackExchange.Redis;
using System;

namespace redis_publisher
{
    class Program
    {
        private const string RedisConnectionString = "localhost:6379";
        private static ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(RedisConnectionString);
        private const string Channel = "test-channel";

        static void Main(string[] args)
        {
            var pubsub = connection.GetSubscriber();
            
            pubsub.PublishAsync(Channel, "This is a test message!!", CommandFlags.FireAndForget);
            Console.Write("Message Successfully sent to test-channel");
            Console.ReadLine();
        }
    }
    
}
