using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMAUIV1._0.Gameplay
{
    public interface ITetronimo
    {
        public void InitializePosition1();
        public void InitializePosition2();
        public void InitializePosition3();
        public void InitializePosition4();

        public void DrawShape();
        public Frame[] Shape {  get; set; }

        public Grid _tetrisGrid { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public int Depth { get; set; }

        public int WidthL { get; set; }

        public int WidthR { get; set; }

        public int CurrentRotation { get; set; }
    }
}
