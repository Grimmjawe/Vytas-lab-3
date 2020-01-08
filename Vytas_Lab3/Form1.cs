using System.Drawing;
using System.Windows.Forms;

namespace Vytas_Lab3
{
    public partial class Form1 : Form
    {
        bool rectangleClicked, circleClicked, squareClicked, swapped = false;
        int x1, x2, x3, y1, y2, y3, X, Y, dX, dY, LastClicked = 0;

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, circle);
            e.Graphics.FillRectangle(Brushes.Blue, square);
            e.Graphics.FillRectangle(Brushes.Yellow, rectangle);
        }

        Rectangle circle = new Rectangle(220, 10, 150, 150);
        Rectangle square = new Rectangle(380, 10, 150, 150);
        Rectangle rectangle = new Rectangle(10, 10, 200, 100);
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            rectangleClicked = false;
            circleClicked = false;
            squareClicked = false;
            if (rectangleClicked)
            {
                LastClicked = 1;
                X = rectangle.X;
                Y = rectangle.Y;
            }
            else if (circleClicked)
            {
                LastClicked = 2;
                X = circle.X;
                Y = circle.Y;
            }
            else
            {
                LastClicked = 3;
                X = square.X;
                Y = square.Y;
            }
            if ((((label2.Location.X < rectangle.X + rectangle.Width) && (label2.Location.X > rectangle.X) &&
                (label2.Location.Y < rectangle.Y + rectangle.Height) && (label2.Location.Y > rectangle.Y)) ||
                ((label2.Location.X < circle.X + circle.Width) && (label2.Location.X > circle.X) &&
                (label2.Location.Y < circle.Y + circle.Height) && (label2.Location.Y > circle.Y)) ||
                ((label2.Location.X < square.X + square.Width) && (label2.Location.X > square.X) &&
                (label2.Location.Y < square.Y + square.Height) && (label2.Location.Y > square.Y)))
                &&
                swapped)
            {
                swapped = false;
                if (rectangleClicked)
                {
                    if (LastClicked == 2)
                    {
                    }
                    else if (LastClicked == 3)
                    {
                    }
                }
                else if (circleClicked)
                {
                    if (LastClicked == 1)
                    {
                    }
                    else if (LastClicked == 3)
                    {
                    }
                }
                else if (squareClicked)
                {
                    if (LastClicked == 1)
                    {
                    }
                    else if (LastClicked == 2)
                    {
                        circle.X = square.X;
                        circle.Y = square.Y;

                        square.X = X;
                        square.Y = Y;
                    }
                }
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (rectangleClicked)
            {
                rectangle.X = e.X - x1;
                rectangle.Y = e.Y - y1;
                if (((label1.Location.X < rectangle.X + rectangle.Width) && (label1.Location.X > rectangle.X) &&
                    (label1.Location.Y < rectangle.Y + rectangle.Height) && (label1.Location.Y > rectangle.Y)))
                {
                    label1.Text = "Желтый";
                    label2.Text = "Прямоугольник";
                    label3.Text = "Желтый прямоугольник";
                }
            }
            else if (circleClicked)
            {
                circle.X = e.X - x2;
                circle.Y = e.Y - y2;
                if (((label1.Location.X < circle.X + circle.Width) && (label1.Location.X > circle.X) &&
                    (label1.Location.Y < circle.Y + circle.Height) && (label1.Location.Y > circle.Y)))
                {
                    label1.Text = "Красный";
                    label2.Text = "Круг";
                    label3.Text = "Красный круг";
                }
            }
            else if (squareClicked)
            {
                square.X = e.X - x3;
                square.Y = e.Y - y3;
                if (((label1.Location.X < square.X + square.Width) && (label1.Location.X > square.X) && 
                    (label1.Location.Y < square.Y + square.Height) && (label1.Location.Y > square.Y)))
                {
                    label1.Text = "Синий";
                    label2.Text = "Квадрат";
                    label3.Text = "Синий квадрат";
                }
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            swapped = true;
            if ((e.X < rectangle.X + rectangle.Width) && (e.X > rectangle.X))
            {
                if ((e.Y < rectangle.Y + rectangle.Height) && (e.Y > rectangle.Y))
                {
                    rectangleClicked = true;

                    x1 = e.X - rectangle.X;
                    y1 = e.Y - rectangle.Y;
                }
            }
            if ((e.X < circle.X + circle.Width) && (e.X > circle.X))
            {
                if ((e.Y < circle.Y + circle.Height) && (e.Y > circle.Y))
                {
                    circleClicked = true;

                    x2 = e.X - circle.X;
                    y2 = e.Y - circle.Y;
                }
            }
            if ((e.X < square.X + square.Width) && (e.X > square.X))
            {
                if ((e.Y < square.Y + square.Height) && (e.Y > square.Y))
                {
                    squareClicked = true;

                    x3 = e.X - square.X;
                    y3 = e.Y - square.Y;
                }
            }
        }
    }
}
