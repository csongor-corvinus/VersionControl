﻿using _8_gyak_patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_gyak_patterns.Entities
{
    public class Present : Toy
    {
        public SolidBrush RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }

        public Present(Color ribbon, Color box)
        {
            RibbonColor = new SolidBrush(ribbon);
            BoxColor = new SolidBrush(box);
        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(BoxColor, 0, 0, Width, Height);
            g.FillRectangle(RibbonColor, (Width/2)-(Width/10), 0, Width/5, Height);
            g.FillRectangle(RibbonColor, 0, (Height/ 2) - (Height / 10), Width, Height / 5);
        }
    }
}
