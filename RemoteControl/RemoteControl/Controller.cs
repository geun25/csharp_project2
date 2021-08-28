using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl
{
    public class Controller
    {
        static Controller singleton;

        public static Controller Singleton
        {
            get
            {
                return singleton;
            }
        }

        static Controller()
        {
            singleton = new Controller();
        }

        private Controller()
        {
        }

        ImageServer img_server = null;
        SendEventClient sce = null;
        public event RecvImageEventHandler RecvedImage = null;
        string host_ip;

        public SendEventClient SendEventClient
        {
            get
            {
                return sce;
            }
        }

        public string MyIP
        {
            get
            {
                return NetworkInfo.DefaultIP;
            }
        }

        public void Start(string host_ip)
        {
            this.host_ip = host_ip;
            img_server = new ImageServer(MyIP, NetworkInfo.ImgPort);
            img_server.RecvedImage += Img_server_RecvedImage;
            SetUpClient.Setup(host_ip, NetworkInfo.SetupPort);
        }

        private void Img_server_RecvedImage(object sender, RecvImageEventArgs e)
        {
            if(RecvedImage != null)
            {
                RecvedImage(this, e);
            }
        }

        public void Stop()
        {
            if(img_server != null)
            {
                img_server.Close();
                img_server = null;
            }
        }
    }
}
