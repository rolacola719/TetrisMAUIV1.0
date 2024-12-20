using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMAUIV1._0.Gameplay.Pieces
{
    class PieceI: PieceParent, ITetronimo
    {
        public override Grid _tetrisGrid {  get; set; }
        public PieceI(Grid TetrisBoard) 
        { 
        _tetrisGrid = TetrisBoard;
        }

        private int posX = 0;
        public int PosX { get { return posX; } set { posX = value; } }

        private int posY = 0;
        public int PosY { get { return posY; } set { posY = value;  } }

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
            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY -1, Colors.Aquamarine);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX , PosY, Colors.Aquamarine);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX , PosY +1, Colors.Aquamarine);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX , PosY +2, Colors.Aquamarine);


            depth = 2;
            widthL = 0;
            widthR = 0;

        }

      

        public override void InitializePosition2()
        {
            Shape[0] = CreateRectangle(_tetrisGrid, PosX-1, PosY, Colors.Aquamarine);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Aquamarine);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX + 1, PosY, Colors.Aquamarine);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX + 2, PosY, Colors.Aquamarine);

           

            depth = 0;
            widthL = 1;
            widthR = 2;


        }

        public override void InitializePosition3()
        {
            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY - 1, Colors.Aquamarine);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Aquamarine);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX, PosY + 1, Colors.Aquamarine);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX, PosY + 2, Colors.Aquamarine);

            Depth = 2;
            WidthL = 0;
            WidthR = 0;

        }

        public override void InitializePosition4()
        {
            shape[0] = CreateRectangle(_tetrisGrid, PosX - 1, PosY, Colors.Aquamarine);
            shape[1] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Aquamarine);
            shape[2] = CreateRectangle(_tetrisGrid, PosX + 1, PosY, Colors.Aquamarine);
            shape[3] = CreateRectangle(_tetrisGrid, PosX + 2, PosY, Colors.Aquamarine);

            Depth = 0;
            WidthL = 1;
            WidthR = 2;


        }

    }
}
