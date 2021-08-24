using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    delegate void RecvImageEventHandler(object sender, RecvImageEventArgs e);

    class RecvImageEventArgs:EventArgs
    {
    }
}
