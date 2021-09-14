using System.Collections.Generic;

namespace WebApiTemplate.Services.AuthConsumer
{
    public class AuthConsumers
    {
        public enum Consumer
        {
            Developer,
            ExampleClientA
        }
        public static Dictionary<Consumer, string> Consumers = new Dictionary<Consumer, string>();
    }

}