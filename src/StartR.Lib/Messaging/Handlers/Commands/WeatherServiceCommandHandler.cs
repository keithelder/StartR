using StartR.Lib.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartR.Lib.Messaging.Handlers.Commands
{
    public class WeatherServiceCommandHandler : IHandle<WeatherServiceCommand>
    {

        public void Handle(WeatherServiceCommand msg, Action completion)
        {
            if(completion != null)
            completion();
        }
    }
}
