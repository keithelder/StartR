using StartR.Lib.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartR.Lib.Messaging.Commands
{
    public class WeatherServiceCommand : ICommand
    {
        public string City { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return City + "," + State;
        }
    }

 
}
