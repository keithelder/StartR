using StartR.Domain;
using StartR.Lib.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartR.Lib.Messaging.Handlers.Commands
{
    public class QualifyNewClientCommandHandler : IHandle<QualifyNewClientCommand>
    {
        public void Handle(QualifyNewClientCommand command, Action completion)
        {
            Console.WriteLine(String.Format("Qualifying new client {0}:{1}:{2}", command.Id, command.FirstName, command.LastName));

            ClientQualification q = new ClientQualification() { BestCallTime = DateTime.Now.AddHours(5), PredictiveCreditScore = 680, QualityRating = 78, TodaysMood = Mood.Happy };
            
            // send this client qualification message to StartR.SignalR queue. 
            
            if (completion != null) completion();
        }
    }
}
