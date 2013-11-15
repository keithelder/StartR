using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using StartR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartR.Web.Hubs
{
    public class Qualification 
    {
        private readonly static Lazy<Qualification> _instance = new Lazy<Qualification>(
            () => new Qualification(GlobalHost.ConnectionManager.GetHubContext<QualificationHub>().Clients)
          );

        public void UpdateQualification(ClientQualification cQual)
        {
            Clients.All.updateQualification(cQual);
        }

           private Qualification(IHubConnectionContext clients)
        {
            Clients = clients;
        }

        public static Qualification Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubConnectionContext Clients
        {
            get;
            set;
        }

    }

    [HubName("qualification")]
    public class QualificationHub : Hub
    {
        private readonly Qualification _clientQualification;

        public QualificationHub() : this(Qualification.Instance) { }

        public QualificationHub(Qualification qualification)
        {
            _clientQualification = qualification;
        }

        //public ClientQualification GetQualification(int id)
        //{
        //    return new ClientQualification()
        //        {
        //            BestCallTime = DateTime.Now,
        //            PredictiveCreditScore = 123,
        //            QualityRating = 3,
        //            TodaysMood = Mood.Happy
        //        };
        //}

        public void UpdateQualification(ClientQualification cQual)
        {
            _clientQualification.UpdateQualification(cQual);
        }
    }
}