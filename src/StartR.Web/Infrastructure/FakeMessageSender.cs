using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StartR.Lib.Messaging;
using StartR.Web.Hubs;
using StartR.Domain;
using System.Threading;

namespace StartR.Web.Infrastructure
{
    public class FakeMessageSender : IMessageSender
    {
        private PoorMansRouter _router;

        public FakeMessageSender()
        {
            _router = new PoorMansRouter();
        }

        public void Send<T>(T msg)
        {
            Thread.Sleep(2000);
            QualificationHub hub = new QualificationHub();
            hub.UpdateQualification(new Domain.ClientQualification() { BestCallTime = DateTime.Now.AddHours(4),
            PredictiveCreditScore = 725,
            QualityRating = 88,
            TodaysMood = Mood.Happy });
        }
    }
}
