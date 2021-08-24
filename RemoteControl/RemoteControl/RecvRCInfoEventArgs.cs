using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    delegate void RecvRVCInfoEventHandler(object sender, RecvRCInfoEventArgs e);

    class RecvRCInfoEventArgs : EventArgs
    {
    }
}
