using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StartR.Lib.Messaging;
using System;
using System.Text;
using Topshelf;
using Topshelf.ServiceConfigurators;

namespace StartR.MessageProcessorService
{

    class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
                {
                    x.Service<IService>(s =>
                        {
                            s.ConstructUsing(name => new Service());
                            s.WhenStarted(tc => tc.Start());
                            s.WhenStopped(tc => tc.Stop());
                        });

                    x.RunAsLocalSystem();
                    x.SetDescription("Processes all messages for the StartR application.");
                    x.SetDisplayName("StartR Message Processor");
                    x.SetServiceName("StartRMessageProcessor");
                }
            );
        }
    }
}