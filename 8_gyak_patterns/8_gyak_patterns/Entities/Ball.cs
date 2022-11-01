using _8_gyak_patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_gyak_patterns.Entities
{
    public class Ball:Toy
    {
        public SolidBrush BallColor { get; private set; }

        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
            Click += Ball_Click;
        }

        Random rnd = new Random();

        private void Ball_Click(object sender, EventArgs e)
        {
            Color color1 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BallColor = new SolidBrush(color1);
            Invalidate();
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

        
    }

}
