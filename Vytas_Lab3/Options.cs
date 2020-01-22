using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vytas_Lab3
{
    public partial class Options : Form
    {
        int x2, y2 = 0;
        bool redClicked, blueClicked, greenClicked, yellowClicked = false;

        Rectangle circle2 = new Rectangle(10, 10, 50, 50);
        Rectangle square2 = new Rectangle(70, 10, 50, 50);
        Rectangle rectangle2 = new Rectangle(140, 10, 25, 70);

        Rectangle red = new Rectangle(10, 100, 20, 20);
        Rectangle blue = new Rectangle(35, 100, 20, 20);
        Rectangle green = new Rectangle(60, 100, 20, 20);
        Rectangle yellow = new Rectangle(85, 100, 20, 20);

        Menu menu;
        Brush circleC, squareC, rectangleC;

        public Options(Brush circleC2, Brush squareC2, Brush rectangleC2, Menu menus)
        {
            menu = menus;
            circleC = circleC2;
            squareC = squareC2;
            rectangleC = rectangleC2;
            InitializeComponent();
            pictureBox2.MouseDown += PictureBox1_MouseDown2;
            pictureBox2.MouseMove += PictureBox1_MouseMove2;
            pictureBox2.MouseUp += PictureBox1_MouseUp2;
        }

        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(circleC, circle2);
            e.Graphics.FillRectangle(squareC, square2);
            e.Graphics.FillRectangle(rectangleC, rectangle2);
            e.Graphics.FillRectangle(Brushes.Red, red);
            e.Graphics.FillRectangle(Brushes.Blue, blue);
            e.Graphics.FillRectangle(Brushes.Green, green);
            e.Graphics.FillRectangle(Brushes.Yellow, yellow);
        }

        private void PictureBox1_MouseUp2(object sender, MouseEventArgs e)
        {
            if (redClicked)
            {
                if ((red.Location.X < circle2.X + circle2.Width) && (red.Location.X > circle2.X - circle2.Width) &&
                (red.Location.Y < circle2.Y + circle2.Height) && (red.Location.Y > circle2.Y - circle2.Width))
                {
                    circleC = Brushes.Red;
                }
                else if ((red.Location.X < square2.X + square2.Width) && (red.Location.X > square2.X - square2.Width) &&
                (red.Location.Y < square2.Y + square2.Height) && (red.Location.Y > square2.Y - square2.Width))
                {
                    squareC = Brushes.Red;
                }
                else if ((red.Location.X < rectangle2.X + rectangle2.Width) && (red.Location.X > rectangle2.X - rectangle2.Width) &&
                (red.Location.Y < rectangle2.Y + rectangle2.Height) && (red.Location.Y > rectangle2.Y - rectangle2.Width))
                {
                    rectangleC = Brushes.Red;
                }
            }
            else if (blueClicked)
            {
                if ((blue.Location.X < circle2.X + circle2.Width) && (blue.Location.X > circle2.X - circle2.Width) &&
                (blue.Location.Y < circle2.Y + circle2.Height) && (blue.Location.Y > circle2.Y - circle2.Width))
                {
                    circleC = Brushes.Blue;
                }
                else if ((blue.Location.X < square2.X + square2.Width) && (blue.Location.X > square2.X - square2.Width) &&
                (blue.Location.Y < square2.Y + square2.Height) && (blue.Location.Y > square2.Y - square2.Width))
                {
                    squareC = Brushes.Blue;
                }
                else if ((blue.Location.X < rectangle2.X + rectangle2.Width) && (blue.Location.X > rectangle2.X - rectangle2.Width) &&
                (blue.Location.Y < rectangle2.Y + rectangle2.Height) && (blue.Location.Y > rectangle2.Y - rectangle2.Width))
                {
                    rectangleC = Brushes.Blue;
                }
            }
            else if (greenClicked)
            {
                if ((green.Location.X < circle2.X + circle2.Width) && (green.Location.X > circle2.X - circle2.Width) &&
                (green.Location.Y < circle2.Y + circle2.Height) && (green.Location.Y > circle2.Y - circle2.Width))
                {
                    circleC = Brushes.Green;
                }
                else if ((green.Location.X < square2.X + square2.Width) && (green.Location.X > square2.X - square2.Width) &&
                (green.Location.Y < square2.Y + square2.Height) && (green.Location.Y > square2.Y - square2.Width))
                {
                    squareC = Brushes.Green;
                }
                else if ((green.Location.X < rectangle2.X + rectangle2.Width) && (green.Location.X > rectangle2.X - rectangle2.Width) &&
                (green.Location.Y < rectangle2.Y + rectangle2.Height) && (green.Location.Y > rectangle2.Y - rectangle2.Width))
                {
                    rectangleC = Brushes.Green;
                }
            }
            else if (yellowClicked)
            {
                if ((yellow.Location.X < circle2.X + circle2.Width) && (yellow.Location.X > circle2.X - circle2.Width) &&
                (yellow.Location.Y < circle2.Y + circle2.Height) && (yellow.Location.Y > circle2.Y - circle2.Width))
                {
                    circleC = Brushes.Yellow;
                }
                else if ((yellow.Location.X < square2.X + square2.Width) && (yellow.Location.X > square2.X - square2.Width) &&
                (yellow.Location.Y < square2.Y + square2.Height) && (yellow.Location.Y > square2.Y - square2.Width))
                {
                    squareC = Brushes.Yellow;
                }
                else if ((yellow.Location.X < rectangle2.X + rectangle2.Width) && (yellow.Location.X > rectangle2.X - rectangle2.Width) &&
                (yellow.Location.Y < rectangle2.Y + rectangle2.Height) && (yellow.Location.Y > rectangle2.Y - rectangle2.Width))
                {
                    rectangleC = Brushes.Yellow;
                }
            }
            redClicked = false;
            blueClicked = false;
            greenClicked = false;
            yellowClicked = false;
            red.X = 10;
            red.Y = 100;
            blue.X = 35;
            blue.Y = 100;
            green.X = 60;
            green.Y = 100;
            yellow.X = 85;
            yellow.Y = 100;
        }

        private void PictureBox1_MouseMove2(object sender, MouseEventArgs e)
        {
            if (redClicked)
            {
                red.X = e.X - x2;
                red.Y = e.Y - y2;
            }
            else if (blueClicked)
            {
                blue.X = e.X - x2;
                blue.Y = e.Y - y2;
            }
            else if (greenClicked)
            {
                green.X = e.X - x2;
                green.Y = e.Y - y2;
            }
            else if (yellowClicked)
            {
                yellow.X = e.X - x2;
                yellow.Y = e.Y - y2;
            }
            pictureBox2.Invalidate();
        }

        private void PictureBox1_MouseDown2(object sender, MouseEventArgs e)
        {
            if (((e.X < red.X + red.Width) && (e.X > red.X - red.Width)) && ((e.Y < red.Y + red.Height) && (e.Y > red.Y - red.Height)))
            {
                redClicked = true;
                x2 = e.X - red.X;
                y2 = e.Y - red.Y;
            }
            else if ((e.X < blue.X + blue.Width) && (e.X > blue.X - blue.Width))
            {
                blueClicked = true;
                x2 = e.X - blue.X;
                y2 = e.Y - blue.Y;
            }
            else if ((e.X < green.X + green.Width) && (e.X > green.X - green.Width))
            {
                greenClicked = true;
                x2 = e.X - green.X;
                y2 = e.Y - green.Y;
            }
            else if ((e.X < yellow.X + yellow.Width) && (e.X > yellow.X - yellow.Width))
            {
                yellowClicked = true;
                x2 = e.X - yellow.X;
                y2 = e.Y - yellow.Y;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            menu.circleC = circleC;
            menu.squareC = squareC;
            menu.rectangleC = rectangleC;
            this.Close();
        }
    }
}
