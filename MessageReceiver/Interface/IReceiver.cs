using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageReceiver.Interface
{
    public interface IReceiver
    {
        public string ReceiveEvent();
    }
}
