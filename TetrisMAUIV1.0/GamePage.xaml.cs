using System.Diagnostics;
using TetrisMAUIV1._0.Gameplay;
using TetrisMAUIV1._0.Gameplay.Pieces;
using SharpHook;
using SharpHook.Native;
using System.ComponentModel;


namespace TetrisMAUIV1._0;
public partial class GamePage : ContentPage
{
    public static Grid TetrisBoard;
    UI uI;
    TaskPoolGlobalHook hook = new TaskPoolGlobalHook();


    public ITetronimo[] UpcomingPieces = new ITetronimo[3];
    public static ITetronimo ActivePiece;
    public int Speed = 200; // in ticks (ms)
    public int[] floor;
    public int score = 0;
    private Label scorelabel;

    public GamePage()
    {
        InitializeComponent();

        scorelabel = ScoreLabel;
        ScoreLabel.Text = score.ToString();
        hook.KeyPressed += OnKeyPressed;
        hook.KeyReleased += OnKeyReleased;
        hook.RunAsync();

        uI = new UI();

        TetrisBoard = uI.DrawGameplayGrid();
        Frame.Add(TetrisBoard);
        PopulateUpcomingPieces();


        TranslateUpcomingPieceToBoard();
    }

    public void PopulateUpcomingPieces()
    {


        for (int i = 0; i < UpcomingPieces.Length; i++)
        {
            if (UpcomingPieces[i] != null) continue;
            else
            {

                int randNum = Random.Shared.Next(1, 7); //Set to 1, 7 - set as 1 ,1 for testing with Piece I

                switch (randNum)
                {
                    case 1:
                        UpcomingPieces[i] = new PieceI(TetrisBoard);
                        break;
                    case 2:
                        UpcomingPieces[i] = new PieceJ(TetrisBoard);
                        break;
                    case 3:
                        UpcomingPieces[i] = new PieceL(TetrisBoard);
                        break;
                    case 4:
                        UpcomingPieces[i] = new PieceS(TetrisBoard);
                        break;
                    case 5:
                        UpcomingPieces[i] = new PieceT(TetrisBoard);
                        break;
                    case 6:
                        UpcomingPieces[i] = new PieceX(TetrisBoard);
                        break;
                    case 7:
                        UpcomingPieces[i] = new PieceZ(TetrisBoard);
                        break;
                }
            }
        }
        UpcomingPieces[0]._tetrisGrid = UpcomingPiece1Grid;
        UpcomingPieces[0].PosX = 1;
        UpcomingPieces[0].PosY = 1;
        UpcomingPieces[0].DrawShape();

        UpcomingPieces[1]._tetrisGrid = UpcomingPiece2Grid;
        UpcomingPieces[1].PosX = 1;
        UpcomingPieces[1].PosY = 1;
        UpcomingPieces[1].DrawShape();

        UpcomingPieces[2]._tetrisGrid = UpcomingPiece3Grid;
        UpcomingPieces[2].PosX = 1;
        UpcomingPieces[2].PosY = 1;
        UpcomingPieces[2].DrawShape();
    }

    public void TranslateUpcomingPieceToBoard()
    {
        
        
        
        ActivePiece = UpcomingPieces[0];
        ActivePiece._tetrisGrid = TetrisBoard;
        ActivePiece.PosX = 4;
        UpcomingPieces[0].DrawShape();

       

        UpcomingPieces[0] = UpcomingPieces[1];
        UpcomingPieces[1] = UpcomingPieces[2];
        UpcomingPieces[2] = null;

        UpcomingPiece1Grid.Children.Clear();
        UpcomingPiece2Grid.Children.Clear();
        UpcomingPiece3Grid.Children.Clear();

        PopulateUpcomingPieces();

        GenerateGravity();
        
        CheckEachColumnForFullLine();
    }
    private async void GenerateGravity()
    {
        do
        {
            floor = FindFloor();
            ActivePiece.PosY++;
            await Task.Delay(Speed);

            foreach (var shape in ActivePiece.Shape)
            {
                TetrisBoard.Children.Remove(shape);
            }

            ActivePiece.DrawShape();

        }
        while (ActivePiece._tetrisGrid == TetrisBoard && ActivePiece.PosY < (floor[ActivePiece.PosX] -1 - ActivePiece.Depth));
        ActivePiece = null;
        TranslateUpcomingPieceToBoard();
    }
    public void OnKeyPressed(Object sender, KeyboardHookEventArgs e)
    {
        if (e.Data.KeyCode == KeyCode.VcA || e.Data.KeyCode == KeyCode.VcLeft)
        {
           

            if (ActivePiece.PosX - ActivePiece.WidthL > 0)
                ActivePiece.PosX--;
            Debug.WriteLine(ActivePiece.WidthL);
        };

        if (e.Data.KeyCode == KeyCode.VcD || e.Data.KeyCode == KeyCode.VcRight)
        {
            if (ActivePiece.PosX + ActivePiece.WidthR < 9)
                ActivePiece.PosX++;
            Debug.WriteLine(ActivePiece.WidthR);
        };

        if (e.Data.KeyCode == KeyCode.VcS || e.Data.KeyCode == KeyCode.VcDown)
        {
            Speed = 50;
        }

        if (e.Data.KeyCode == KeyCode.VcW || e.Data.KeyCode == KeyCode.VcUp)
        {
            ActivePiece.CurrentRotation++;
        }

    }

    public void OnKeyReleased(Object sender, KeyboardHookEventArgs e)
    {

        if (e.Data.KeyCode == KeyCode.VcS || e.Data.KeyCode == KeyCode.VcDown)
        {
            Speed = 350;
        }
    }

    private int[] FindFloor()
    {
        var floor = new int[10] { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };

        foreach (var child in TetrisBoard)
        { if (child != ActivePiece.Shape[0] && child != ActivePiece.Shape[1] && child != ActivePiece.Shape[2] && child != ActivePiece.Shape[3])
            { 
            int column = TetrisBoard.GetColumn(child);
            int row = TetrisBoard.GetRow(child);

                if (row < floor[column] || floor[column] == 0)
                {
                    floor[column] = row;
                }
            }
        }
        return floor;
    }

    private bool[,] OccupiedCellsOnGrid = new bool[20, 10];
    private void CheckEachColumnForFullLine()
    {   
        for(int i = 0; i<20; i++)
        {
            bool alltrueinrow = true;
            for (int j = 0; j < 10; j++)
            {
                OccupiedCellsOnGrid[i, j] = TetrisBoard.Children.Any(child =>
                TetrisBoard.GetRow(child) == i && TetrisBoard.GetColumn(child) == j);

                if (OccupiedCellsOnGrid[i, j] == false) alltrueinrow = false;
            }

            if (alltrueinrow)
            {
                RemoveChildrenFromRow(i);
                DropAllCellsAboveDeletedRow(i);
            }

        }

        void RemoveChildrenFromRow(int targetRow)
       {
            var childrenToRemove = new List<View>();
            // Iterate over the grid's children
            foreach (var child in TetrisBoard)
            {
                // Check if the child is in the target row
                if (TetrisBoard.GetRow(child) == targetRow)
                {
                    // Add the child to the removal list
                    childrenToRemove.Add((View)child);
                }
            }
            foreach (var child in childrenToRemove)
            {
                TetrisBoard.Children.Remove(child);
            }

            score += 50;
            ScoreLabel.Text = score.ToString();

        }

        void DropAllCellsAboveDeletedRow(int targetRow)
        {
            var childrenToDrop = new List<View>();
            // Iterate over the grid's children
            foreach (var child in TetrisBoard)
            {
                // Check if the child is in the target row
                if (TetrisBoard.GetRow(child) < targetRow)
                {
                    // Add the child to the removal list
                    childrenToDrop.Add((View)child);
                }
            }
            foreach (var child in childrenToDrop)
            {
                int childsRow = TetrisBoard.GetRow(child);
                childsRow++;
                //TetrisBoard.Remove(child);
                TetrisBoard.SetRow(child, childsRow);
                

                //TetrisBoard.Add(child);
            }

        }



    }


}