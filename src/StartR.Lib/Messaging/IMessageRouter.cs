using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartR.Lib.Messaging
{
    public interface IMessageRouter
    {
        void Route<T>(T msg) where T : class, IMessage;
        void Route<T>(T msg, Action completion) where T : class, IMessage;
        void Route(string message, Action completion);
    }
}
