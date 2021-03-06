using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        Game game;
        int bx;
        int by;
        int bwidth;
        int bheight;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = Game.Singleton;
            bx = GameRule.BX;
            by = GameRule.BY;
            bwidth = GameRule.B_WIDTH;
            bheight = GameRule.B_HEIGHT;
            SetClientSizeCore(bx * bwidth, by * bheight);         
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true; // 깜빡임 제거
            DrawGradation(e.Graphics); // 좌표
            DrawDiagram(e.Graphics); // 도형
            DrawBoard(e.Graphics);
        }

        private void DrawBoard(Graphics graphics)
        {
            for(int xx=0; xx<bx; xx++)
            {
                for(int yy=0; yy<by; yy++)
                {
                    if(game[xx, yy] != 0)
                    {
                        Rectangle now_rt = new Rectangle(xx * bwidth + 2, yy * bheight + 2, bwidth - 4, bheight - 4);
                        graphics.DrawRectangle(Pens.Green, now_rt);
                        graphics.FillRectangle(Brushes.Red, now_rt);
                    }
                }
            }
        }

        private void DrawDiagram(Graphics graphics)
        {
            Pen dpen = new Pen(Color.Red, 4);
            Point now = game.NowPosition;
            int bn = game.BlockNum;
            int tn = game.Turn;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                    {
                        Rectangle now_rt = new Rectangle((now.X + xx) * bwidth + 2, (now.Y + yy) * bheight + 2, bwidth - 4, bheight - 4);
                        graphics.DrawRectangle(dpen, now_rt);
                    }
                }
            }
        }

        private void DrawGradation(Graphics graphics)
        {
            DrawHorizons(graphics);
            DrawVerticals(graphics);
        }

        private void DrawVerticals(Graphics graphics)
        {
            Point st = new Point();
            Point et = new Point();
            for (int cx = 0; cx < bx; cx++)
            {
                st.X = cx * bwidth;
                st.Y = 0;
                et.X = st.X;
                et.Y = by * bheight;
                graphics.DrawLine(Pens.Purple, st, et);
            }
        }

        private void DrawHorizons(Graphics graphics)
        {
            Point st = new Point();
            Point et = new Point();
            for (int cy = 0; cy < by; cy++)
            {
                st.X = 0;
                st.Y = cy * bheight;
                et.X = bx * bwidth;
                et.Y = st.Y;
                graphics.DrawLine(Pens.Green, st, et);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right: MoveRight(); return;
                case Keys.Left: MoveLeft(); return;
                case Keys.Space: MoveSDown(); return;
                case Keys.Up: MoveTurn(); return;
                case Keys.Down: MoveDown(); return;
            }
        }

        private void MoveSDown()
        {
            while (game.MoveDown())
            {
                Region rg = MakeRegion(0, -1);
                Invalidate(rg);
            }
            EndingCheck();
        }

        private void MoveTurn()
        {
            if(game.MoveTurn())
            {
                Region rg = MakeRegion();
                Invalidate(rg);
            }
        }

        private void MoveDown()
        {
            if (game.MoveDown())
            {
                Region rg = MakeRegion(0, -1); // 한칸 밑으로 이동했으니 cy좌표 1감소
                Invalidate(rg);
            }
            else
            {
                EndingCheck();
            }
        }

        private void EndingCheck()
        {
            if (game.Next())
            { 
                Invalidate();
            }
            else
            {
                timer_down.Enabled = false;
                DialogResult re = MessageBox.Show("다시 시작", "의사", MessageBoxButtons.YesNo);
                if(re == DialogResult.Yes)
                {
                    game.Restart();
                    timer_down.Enabled = true;
                    Invalidate();
                }
                else
                {
                    Close();
                }
            }
        }

        private void MoveLeft()
        {
            if (game.MoveLeft())
            {
                Region rg = MakeRegion(1, 0);
                Invalidate(rg);
            }
        }

        private void MoveRight()
        {
            if (game.MoveRight())
            {
                Region rg = MakeRegion(-1, 0);
                Invalidate(rg);
            }
        }

        private Region MakeRegion(int cx, int cy)
        {
            Point now = game.NowPosition;
            int bn = game.BlockNum;
            int tn = game.Turn;          

            Region region = new Region();
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                    {
                        Rectangle rect1 = new Rectangle((now.X + xx) * bwidth, (now.Y + yy) * bheight, bwidth, bheight);
                        Rectangle rect2 = new Rectangle((now.X + cx +  xx) * bwidth, (now.Y + cy + yy) * bheight, bwidth, bheight);
                        Region rg1 = new Region(rect1);
                        Region rg2 = new Region(rect2);
                        region.Union(rg1);
                        region.Union(rg2);
                    }
                }
            }
            return region;
        }

        private Region MakeRegion()
        {
            Point now = game.NowPosition;
            int bn = game.BlockNum;
            int tn = game.Turn;
            int oldtn = (tn + 3) % 4; // Turn을 하기전

            Region region = new Region();
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                    {
                        Rectangle rect1 = new Rectangle((now.X + xx) * bwidth + 2, (now.Y + yy) * bheight + 2, bwidth - 4, bheight - 4);
                        Region rg1 = new Region(rect1);
                        region.Union(rg1);
                    }
                    if (BlockValue.bvals[bn, oldtn, xx, yy] != 0)
                    {
                        Rectangle rect1 = new Rectangle((now.X + xx) * bwidth + 2, (now.Y + yy) * bheight + 2, bwidth - 4, bheight - 4);
                        Region rg1 = new Region(rect1);
                        region.Union(rg1);
                    }
                }
            }
            return region;
        }      

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveDown();
        }
    }
}
