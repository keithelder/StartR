using RabbitMQ.Client;
using StartR.Lib.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XSerializer;

namespace StartR.Lib.Infrastructure
{
    public class RabbitMQMessageSender : IMessageSender
    {
        private static ConnectionFactory s_factory;
        private static IModel s_channel;
        private static IConnection s_connection;

        private static void Initialize()
        {
            s_factory = new ConnectionFactory() { HostName = "localhost" };
            s_connection = s_factory.CreateConnection();
            s_channel = s_connection.CreateModel();
            s_channel.QueueDeclare("StartR", true, false, false, null);
        }
        static RabbitMQMessageSender()
        {
            Initialize();
        }

        public void Send<T>(T msg)
        {
            XmlSerializer<T> ser = new XmlSerializer<T>();
            var body = Encoding.UTF8.GetBytes(ser.Serialize(msg));
            s_channel.BasicPublish("", "StartR", null, body);
        }

        ~RabbitMQMessageSender()
        {
            s_channel.Dispose();
            s_connection.Dispose();
        }
    }
}