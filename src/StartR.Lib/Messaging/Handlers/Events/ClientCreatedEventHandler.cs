using StartR.Domain;
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

        public void Handle(ClientCreatedEvent msg, Action completion)
        {
            if (completion != null)
                completion();
        }
    }
}
