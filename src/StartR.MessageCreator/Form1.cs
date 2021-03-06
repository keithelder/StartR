﻿using StartR.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using StartR.Lib.Messaging.Events;
using RabbitMQ.Client;
using XSerializer;
using StartR.Domain;
using StartR.Lib.Messaging.Commands;

namespace StartR.MessageCreator
{
    public partial class Form1 : Form
    {
        private RabbitMQMessageSender _Queue;
        public Form1()
        {
            InitializeComponent();
            _Queue = new RabbitMQMessageSender();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("StartR", true, false, false, null);
                    var client = new ClientCreatedEvent();
                    client.FirstName = "Keith";
                    client.LastName = "Elder";
                    client.State = "MS";
                    client.Zip = "39401";
                    client.City = "Hattiesburg";
                    client.Address1 = "somwhere";
                    client.Address2 = "address 2";
                    client.CreateDate = DateTime.Now;
                    client.Id = 1000;
                    var ser = new XmlSerializer<ClientCreatedEvent>();
                    var body = Encoding.UTF8.GetBytes(ser.Serialize(client));
                    channel.BasicPublish("", "StartR", null, body);
                    toolStripStatusLabel1.Text = "Done...";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("StartR.SignalR", true, false, false, null);
                    
                    ClientQualification qual = new ClientQualification();
                    qual.BestCallTime = DateTime.Now.AddHours(5);
                    qual.PredictiveCreditScore = 725;
                    qual.QualityRating = 75;
                    qual.TodaysMood = "Happy Happy";

                    var ser = new XmlSerializer<ClientQualification>();
                    var body = Encoding.UTF8.GetBytes(ser.Serialize(qual));
                    channel.BasicPublish("", "StartR.SignalR", null, body);
                    toolStripStatusLabel1.Text = "Done...";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("StartR", true, false, false, null);
                    StartREntities db = new StartREntities();
                    var q = db.Clients.OrderBy(m => m.LastName).Take(10);
                    foreach (var client in q)
                    {
                        QualifyClientCommand cmd = new QualifyClientCommand();
                        cmd.Address1 = client.Address1;
                        cmd.Address2 = client.Address2;
                        cmd.City = client.City;
                        cmd.FirstName = client.FirstName;
                        cmd.Id = client.Id;
                        cmd.LastName = client.LastName;
                        cmd.State = client.State;
                        cmd.Zip = client.Zip;
                        var ser = new XmlSerializer<QualifyClientCommand>();
                        var body = Encoding.UTF8.GetBytes(ser.Serialize(cmd));
                        channel.BasicPublish("", "StartR", null, body);
                    }
                }
                toolStripStatusLabel1.Text = "Done sending clients.";
            }
        }
    }
}
