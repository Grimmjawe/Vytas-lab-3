using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vytas_Lab3
{
    public partial class Form1 : Form
    {
        bool circleClicked = false;
        int score, x2, LastClicked = 0;
        int speed = 2;

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, circle);
            e.Graphics.FillRectangle(Brushes.Yellow, rectangle);
        }

        Rectangle circle = new Rectangle(175, 600, 50, 50);
        Rectangle square = new Rectangle(380, 10, 75, 75);
        Rectangle rectangle = new Rectangle(50, 50, 33, 75);
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            Timer timer1 = new Timer { Interval = 1, Enabled = true };
            timer1.Tick += new EventHandler(OnTimerEvent);
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            rectangle.Y = rectangle.Y + speed;
            if ((rectangle.Location.X < circle.X + circle.Width) && (rectangle.Location.X > circle.X - circle.Width) &&
                (rectangle.Location.Y < circle.Y + circle.Height) && (rectangle.Location.Y > circle.Y - circle.Width))
            {
                score = score + 10;
                if(score % 100 == 0)
                {
                    speed = speed + 2;
                }
                label1.Text = score.ToString();
                rectangle.Y = 50;
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (((label1.Location.X < rectangle.X + rectangle.Width) && (label1.Location.X > rectangle.X) &&
                (label1.Location.Y < rectangle.Y + rectangle.Height) && (label1.Location.Y > rectangle.Y)))
            {
                if (circleClicked)
                {
                    if (LastClicked == 2)
                    {
                        circle.X = rectangle.X;
                        circle.Y = rectangle.Y;
                    }
                    else if (LastClicked == 3)
                    {
                        square.X = rectangle.X;
                        square.Y = rectangle.Y;
                    }
                }
            }
            if (circleClicked)
            {
            }
            circleClicked = false;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (circleClicked)
            {
                if (e.X > 50 && e.X < 350)
                {
                    circle.X = e.X - x2;
                }
                if (((label1.Location.X < circle.X + circle.Width) && (label1.Location.X > circle.X) &&
                    (label1.Location.Y < circle.Y + circle.Height) && (label1.Location.Y > circle.Y)))
                {
                }
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X < circle.X + circle.Width) && (e.X > circle.X))
            {
                if ((e.Y < circle.Y + circle.Height) && (e.Y > circle.Y))
                {
                    circleClicked = true;
                    x2 = e.X - circle.X;
                }
            }
        }
    }
}
