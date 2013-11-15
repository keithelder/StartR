using RabbitMQ.Client;
using StartR.Domain;
using StartR.Lib.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XSerializer;

namespace StartR.Lib.Messaging.Handlers.Commands
{
    public class QualifyNewClientCommandHandler : IHandle<QualifyClientCommand>
    {

        public void Handle(QualifyClientCommand command, Action completion)
        {
            Console.WriteLine(String.Format("Qualifying new client {0}:{1}:{2}", command.Id, command.FirstName, command.LastName));
            Thread.Sleep(3000);
            ClientQualification q = new ClientQualification() { BestCallTime = DateTime.Now.AddHours(5), PredictiveCreditScore = 680, QualityRating = 78, TodaysMood = "Sunny at Home, birthday last week, (F) child got good grades (T) recently went to Germany" };
            
            // send this client qualification message to StartR.SignalR queue. 

            SendToPushNotificationService(q);

            if (completion != null) completion();
        }
        private void SendToPushNotificationService(ClientQualification q)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("StartR.SignalR", true, false, false, null);
                    var ser = new XmlSerializer<ClientQualification>();
                    var body = Encoding.UTF8.GetBytes(ser.Serialize(q));
                    channel.BasicPublish("", "StartR.SignalR", null, body);
                }
            }
        }
    }
}
