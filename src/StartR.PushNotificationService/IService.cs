using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StartR.Lib.Messaging;
using System;
using System.Text;

namespace StartR.PushNotificationService
{
    public interface IService
    {
        void Stop();
        void Start();
    }
}
