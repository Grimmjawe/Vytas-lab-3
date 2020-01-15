using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vytas_Lab3
{
    public partial class Form1 : Form
    {
        bool circleClicked = false;
        int score, x2, LastClicked = 0;
        int speed = 4;
        Random rand = new Random();
        Timer timer1 = new Timer { Interval = 1};
        Rectangle circle = new Rectangle(175, 600, 50, 50);
        Rectangle square = new Rectangle(250, -80, 50, 50);
        Rectangle rectangle = new Rectangle(50, -200, 25, 70);

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, circle);
            e.Graphics.FillRectangle(Brushes.Blue, square);
            e.Graphics.FillRectangle(Brushes.Yellow, rectangle);
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            timer1.Tick += new EventHandler(OnTimerEvent);
            label1.Size = new Size(100, 33);
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            label1.Text = score.ToString();
            square.Y = square.Y + speed;
            rectangle.Y = rectangle.Y + speed;
            if ((rectangle.Location.X < circle.X + circle.Width) && (rectangle.Location.X > circle.X - circle.Width) &&
            (rectangle.Location.Y < circle.Y + circle.Height) && (rectangle.Location.Y > circle.Y - circle.Width))
            {
                AddScore();
                rectangle.X = rand.Next(50, 350);
                rectangle.Y = 0;
            }
            else if ((square.Location.X < circle.X + circle.Width) && (square.Location.X > circle.X - circle.Width) &&
            (square.Location.Y < circle.Y + circle.Height) && (square.Location.Y > circle.Y - circle.Width))
            {
                AddScore();
                square.X = rand.Next(50, 350);
                square.Y = 0;
            }
            if (rectangle.Location.Y > 650 || square.Location.Y > 650)
            {
                label1.Text = "You lose last score: " + score;
                timer1.Enabled = false;
                button1.Enabled = true;
                button1.Text = "Restart";
            }
            pictureBox1.Invalidate();
        }

        private void AddScore()
        {
            score = score + 1;
            if (score % 10 == 0)
            {
                speed = speed + 2;
            }
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
            circleClicked = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (circle.X > 25 && circle.X < 375)
            {
                if (e.KeyCode == Keys.Left && circle.X > 50)
                {
                    circle.X = circle.X - 25;
                }
                else if (e.KeyCode == Keys.Right && circle.X < 350)
                {
                    circle.X = circle.X + 25;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            square.Y = -80;
            rectangle.Y = -200;
            timer1.Enabled = true;
            button1.Enabled = false;
            button1.Text = "";
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (circleClicked)
            {
                if (e.X > 50 && e.X < 350)
                {
                    circle.X = e.X - x2;
                }
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X < circle.X + circle.Width) && (e.X > circle.X - circle.Width))
            {
                circleClicked = true;
                x2 = e.X - circle.X;
            }
        }
    }
}
