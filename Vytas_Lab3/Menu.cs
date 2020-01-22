using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vytas_Lab3
{
    public partial class Menu : Form
    {
        public Brush circleC, squareC, rectangleC;

        public Menu(Brush circleC2, Brush squareC2, Brush rectangleC2)
        {
            circleC = circleC2;
            squareC = squareC2;
            rectangleC = rectangleC2;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Form1(circleC, squareC, rectangleC).Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new Options(circleC, squareC, rectangleC, this).Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
