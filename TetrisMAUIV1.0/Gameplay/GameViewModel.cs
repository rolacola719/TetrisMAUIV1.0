using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisMAUIV1._0.Gameplay.Pieces;

namespace TetrisMAUIV1._0.Gameplay
{
    public class GameViewModel : ObservableObject, INotifyPropertyChanged
    {
        public ITetronimo[] UpcomingPieces = new ITetronimo[3];

        public Grid _tetrisBoard { get; set; }
        public Grid _upcomingPiece1Grid { get; set; }
        public Grid _upcomingPiece2Grid { get; set; }
        public Grid _upcomingPiece3Grid { get; set; }

        private int _activePiecePosX;
        public int ActivePiecePosX
        {
            get => _activePiecePosX;
            set
            {
                if (_activePiecePosX != value)
                {
                    _activePiecePosX = value;
                    OnPropertyChanged(nameof(_activePiecePosX));  // Notify that MyVariable has changed
                }
            }
        }

        private int _activePiecePosY;
        public int ActivePiecePosY
        {
            get => _activePiecePosY;
            set
            {
                if (_activePiecePosY != value)
                {
                    _activePiecePosY = value;
                    OnPropertyChanged(nameof(_activePiecePosY));  // Notify that MyVariable has changed
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
