using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisMAUIV1._0.Gameplay
{
    public class UI
    {
        public Grid DrawGameplayGrid()
        {
            Grid gameboard = new Grid();

            int boardWidth = 300;

            gameboard.BackgroundColor = Colors.Blue;
            gameboard.WidthRequest = boardWidth;
            gameboard.HeightRequest = boardWidth * 2;
            gameboard.VerticalOptions = LayoutOptions.CenterAndExpand;

            for (int i = 0; i < 10; i++)
            {
                gameboard.AddColumnDefinition(new ColumnDefinition());
            }

            for (int i = 0; i < 20; i++)
            {
                gameboard.AddRowDefinition(new RowDefinition());
            }

            return gameboard;
        }


       
    }
}
