using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartR.MessageProcessorService
{
    public interface IService
    {
        void Stop();
        void Start();
    }
}
