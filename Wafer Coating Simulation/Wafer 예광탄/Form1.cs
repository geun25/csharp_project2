using System;
using System.Drawing;
using System.Windows.Forms;
using WaferLineLib;

namespace Wafer_예광탄
{
    public partial class Form1 : Form
    {
        Wafer Wafer
        {
            get;
            set;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            tm_coating.Enabled = true;
            btn_start.Enabled = false;
        }

        Random rand = new Random();
        private void tm_coating_Tick(object sender, EventArgs e)
        {
            if(Wafer == null)
                Wafer = new Wafer();
            Wafer.Coating(rand.Next(70, 100));
            if (Wafer.Increment() == false)
            {
                tm_coating.Enabled = false;
                btn_start.Enabled = true;
                Wafer = null;
            }
            pn_wafer.Invalidate();
        }

        private void pn_wafer_Paint(object sender, PaintEventArgs e)
        {
            // 패널에 내접하는 원 표현
            Graphics graphics = e.Graphics;
            Brush brush = Brushes.Silver;
            Rectangle rect = new Rectangle(0, 0, pn_wafer.Width, pn_wafer.Height);
            graphics.FillEllipse(brush, rect);
            
            // 원에 내접하는 사각형 표현
            int width = pn_wafer.Width;
            int height = pn_wafer.Height;
            int sx = (int)(width * 0.15);
            int sy = (int)(height * 0.15);
            Rectangle rect2 = new Rectangle(sx, sy, (int)(width * 0.7), (int)(height * 0.7));
            graphics.DrawRectangle(Pens.Red, rect2);

            // 사각형을 100개의 cell로 표현
            int xu = rect2.Width / 10;
            int yu = rect2.Height / 10;
            Pen pen = new Pen(Color.DarkGray, 1);
            
            for(int x = 1; x < 10; x++) // 수직선
            {
                graphics.DrawLine(pen, new Point(sx + x * xu, sy), new Point(sx + x * xu, sy + rect2.Height));
            }
            for (int y = 1; y < 10; y++) // 수평선
            {
                graphics.DrawLine(pen, new Point(sx, sy + y * yu), new Point(sx + rect2.Width, sy + y * yu));
            }

            if (Wafer == null)
                return;

            int dir = 0;
            int step = 1, nowstep = step;
            int nx = 4, ny = 5;
            for (int i = 0; i < 100; i++)
            {
                int qual = Wafer[i];
                Color color = Color.FromArgb(200 - qual * 2, 55 + qual * 2, 0);
                Rectangle rt = new Rectangle(sx + nx * xu + 1, sy + ny * yu + 1, xu - 1, yu - 1);
                graphics.FillRectangle(new SolidBrush(color), rt);
                if (nowstep == 0) // 꺾을 방향 조정
                {
                    dir = (dir + 1) % 4; // 0,1,2,3,0,1,2 ...
                    if (dir % 2 == 0) // 1,1,2,2,3,3 ...
                        step++;
                    nowstep = step;
                }
                nowstep--;
                switch (dir)
                {
                    case 0: ny--; break; //위로 이동
                    case 1: nx++; break; // 오른쪽으로 이동
                    case 2: ny++; break;
                    case 3: nx--; break;
                }
            }
        }
    }
}
