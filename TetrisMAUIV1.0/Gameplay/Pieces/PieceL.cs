using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMAUIV1._0.Gameplay.Pieces
{
    class PieceL: PieceParent, ITetronimo
    {

        
        public override Grid _tetrisGrid {  get; set; }
        public PieceL(Grid TetrisBoard) 
        {
            _tetrisGrid = TetrisBoard;
            InitializePosition1();
        }

        private int posX = 0;
        public int PosX { get { return posX; } set { posX = value; } }

        private int posY = 0;
        public int PosY { get { return posY; } set { posY = value; } }

        private int depth;
        public int Depth { get { return depth; } set { depth = value; } }

        private int widthL;
        public int WidthL { get { return widthL; } set { widthL = value; } }

        private int widthR;
        public int WidthR { get { return widthR; } set { widthR = value; } }

        private Frame[] shape = new Frame[4];
        public override Frame[] Shape { get { return shape; } set { shape = value; } }
        public override void InitializePosition1()
        {

            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY -1, Colors.Orange);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX , PosY, Colors.Orange);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX , PosY +1, Colors.Orange);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX + 1 , PosY +1, Colors.Orange);

            Depth = 1;
            WidthL = 0;
            WidthR = 1;

        }

        public override void InitializePosition2()
        {


            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Orange);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX -1, PosY, Colors.Orange);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX +1, PosY, Colors.Orange);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX + 1, PosY - 1, Colors.Orange);

            Depth = 0;
            WidthL = 1;
            WidthR = 1;

        }

        public override void InitializePosition3()
        {


            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Orange);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX , PosY -1, Colors.Orange);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX -1 , PosY -1, Colors.Orange);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX , PosY + 1, Colors.Orange);

            Depth = 1;
            WidthL = 1;
            WidthR = 0;

        }

        public override void InitializePosition4()
        {


            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Orange);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX + 1, PosY, Colors.Orange);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX - 1, PosY, Colors.Orange);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX - 1, PosY + 1, Colors.Orange);

            Depth = 0;
            WidthL = 1;
            WidthR = 1;

        }
    }
}
