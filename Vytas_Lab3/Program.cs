using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vytas_Lab3
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Brush circleC = Brushes.Red;
            Brush squareC = Brushes.Blue;
            Brush rectangleC = Brushes.Yellow;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu(circleC, squareC, rectangleC));
        }
    }
}
