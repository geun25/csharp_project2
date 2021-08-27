using RemoteControl;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace 이미지_캡처_및_전송_클라이언트
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ip;
        ImageClient ic;

        private void button1_Click(object sender, EventArgs e)
        {
            ip = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ic == null)
                return;
            int left = trackBar1.Value;
            int right = trackBar3.Value;
            if (left > right)
            {
                int temp = left;
                left = right;
                right = temp;
            }

            int top = trackBar2.Value;
            int bottom = trackBar4.Value;
            if(top > bottom)
            {
                int temp = top;
                top = bottom;
                bottom = temp;
            }

            int width = right - left;
            int height = bottom - top;
            if ((width == 0) || (height == 0))
                return;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics gr = Graphics.FromImage(bitmap);
            Size size = new Size(width, height);
            gr.CopyFromScreen(new Point(left, top), new Point(0, 0), size);
            ic.Connect(ip, 10200);
            ic.SendImage(bitmap);
            ic.Close();
            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ic = new ImageClient();
            trackBar1.Maximum = trackBar3.Maximum = Screen.PrimaryScreen.Bounds.Width;
            trackBar2.Maximum = trackBar4.Maximum = Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
