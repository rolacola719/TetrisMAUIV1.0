using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using System.ComponentModel;


namespace TetrisMAUIV1._0.Gameplay.Pieces
{
    abstract class PieceParent : ITetronimo
    {
        public abstract Frame[] Shape { get; set; }
        public abstract Grid _tetrisGrid { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Depth { get; set; }
        public int WidthL { get; set; }
        public int WidthR { get; set; }

        private int currentRotation = 1;
        public int CurrentRotation { get { return currentRotation; } set { currentRotation = value; if (value > 4) currentRotation = 1; if (value < 1) currentRotation = 4; } }

        protected Frame CreateRectangle(Grid tetrisBoard, int col, int row, Microsoft.Maui.Graphics.Color color)
        {
            Frame rect = new Frame() { BorderColor = Colors.Black, CornerRadius = 2, Margin = 0.2, BackgroundColor= color};

            tetrisBoard.SetRow(rect, row);
            tetrisBoard.SetColumn(rect, col);

            return rect;
        }

        public void DrawShape()
        {
            switch (currentRotation)
            {
                case 1: InitializePosition1(); break;
                case 2: InitializePosition2(); break;
                case 3: InitializePosition3(); break;
                case 4: InitializePosition4(); break;
            }
            foreach (var i in Shape)
            {
                _tetrisGrid.Add(i);
            }
        }


        public abstract void InitializePosition1();
        public abstract void InitializePosition2();
        public abstract void InitializePosition3();
        public abstract void InitializePosition4();

    }
}
