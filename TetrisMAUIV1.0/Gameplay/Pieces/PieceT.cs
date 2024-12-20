using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMAUIV1._0.Gameplay.Pieces
{
    class PieceT: PieceParent, ITetronimo

    {
       
        public override Grid _tetrisGrid {  get; set; }
        public PieceT(Grid TetrisBoard) 
        
        {
            _tetrisGrid = TetrisBoard;
            InitializePosition1();
        }

        private int posX;
        public int PosX { get { return posX; } set { posX = value; } }

        private int posY;
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



            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Purple);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX + 1, PosY, Colors.Purple);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX - 1, PosY, Colors.Purple);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX, PosY +1, Colors.Purple);

            
            Depth = 1;
            WidthL = 1;
            WidthR = 1;
                
   
        }

        public override void InitializePosition2()
        {



            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Purple);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX -1, PosY, Colors.Purple);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX , PosY +1, Colors.Purple);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX, PosY -1, Colors.Purple);

           
            Depth = 1;
            WidthL = 1;
            WidthR = 0;

        }
        public override void InitializePosition3()
        {



            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Purple);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX, PosY -1, Colors.Purple);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX +1, PosY, Colors.Purple);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX -1, PosY, Colors.Purple);

          

            Depth = 0;
            WidthL = 1;
            WidthR = 1;

           
        }

        public override void InitializePosition4()
        {



            Shape[0] = CreateRectangle(_tetrisGrid, PosX, PosY, Colors.Purple);
            Shape[1] = CreateRectangle(_tetrisGrid, PosX + 1, PosY, Colors.Purple);
            Shape[2] = CreateRectangle(_tetrisGrid, PosX, PosY + 1, Colors.Purple);
            Shape[3] = CreateRectangle(_tetrisGrid, PosX, PosY - 1, Colors.Purple);

           

            Depth = 1;
            WidthL = 0;
            WidthR = 1;

      
        }

    }
}
