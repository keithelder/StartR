using StartR.Domain;
using StartR.Lib.Infrastructure;
using StartR.Lib.Messaging.Commands;
using StartR.Lib.Messaging.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartR.Lib.Messaging.Handlers.Events
{
    public class ClientCreatedEventHandler : IHandle<ClientCreatedEvent>
    {
        IMessageSender sender = new RabbitMQMessageSender(); //TODO: IOC

        public void Handle(ClientCreatedEvent msg, Action completion)
        {
            QualifyClientCommand cmd = new QualifyClientCommand();
            cmd.Address1 = msg.Address1;
            cmd.Address2 = msg.Address2;
            cmd.City = msg.City;
            cmd.CreateDate = DateTime.Now;
            cmd.FirstName = msg.FirstName;
            cmd.Id = msg.Id;
            cmd.LastName = msg.LastName;
            cmd.State = msg.State;
            cmd.Zip = msg.Zip;

            sender.Send<QualifyClientCommand>(cmd);
            if (completion != null)
                completion();
        }
    }
}
