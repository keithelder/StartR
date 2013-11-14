using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StartR.Domain;

namespace StartR.Lib.Messaging
{
    public interface IHandleCallBackEntity<IMessage, IEntity>
    {
        void Handle(ICommand msg, Action<IEntity> completion);
    }
}
