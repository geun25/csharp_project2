using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    delegate void RecvKMEEventHandler(object sender, RecvKMEEventArgs e);

    class RecvKMEEventArgs:EventArgs
    {
    }
}
