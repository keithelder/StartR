using StartR.Domain;
using StartR.Lib.Messaging.Commands;
using StartR.Lib.Messaging.Events;
using StartR.Lib.Messaging.Handlers.Commands;
using StartR.Lib.Messaging.Handlers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XSerializer;

namespace StartR.Lib.Messaging
{
    public class PoorMansRouter : IMessageRouter
    {
        IList<Type> _types = new List<Type>();

        public PoorMansRouter()
        {
            
        }

        public void Route<T>(T msg) where T : class, IMessage
        {
            throw new NotImplementedException();
        }

        public void Route<T>(T msg, Action completion) where T : class, IMessage
        {
            throw new NotImplementedException();
        }

        public void Route(string message, Action completion)
        {
            XDocument msg = XDocument.Parse(message);
            var rootElement = msg.Elements().FirstOrDefault().Name.ToString();

            switch (rootElement)
            {
                case "ClientCreatedEvent":
                    RouteClientCreateEvent(message, completion);
                    break;

                case "QualifyNewClientCommand":
                    RouteQualifyNewClientCommand(message, completion);
                    break;
            }

        }

        private static void RouteClientCreateEvent(string message, Action completion)
        {
            XmlSerializer<ClientCreatedEvent> serializer = new XmlSerializer<ClientCreatedEvent>();
            var cmd = serializer.Deserialize(message);
            var handler = new ClientCreatedEventHandler();
            handler.Handle(cmd, completion);
        }

        private static void RouteQualifyNewClientCommand(string message, Action completion)
        {
            XmlSerializer<QualifyNewClientCommand> qSer = new XmlSerializer<QualifyNewClientCommand>();
            var qcmd = qSer.Deserialize(message);
            var handler = new QualifyNewClientCommandHandler();
            handler.Handle(qcmd, completion);
        }
    }
}
