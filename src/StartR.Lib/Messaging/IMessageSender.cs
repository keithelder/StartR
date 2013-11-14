using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartR.Lib.Messaging
{
    public interface IMessageSender
    {
        void Send<T>(T msg);
    }
}
