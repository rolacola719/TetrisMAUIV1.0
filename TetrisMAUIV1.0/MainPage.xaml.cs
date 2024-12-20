using TetrisMAUIV1._0.Gameplay;

namespace TetrisMAUIV1._0
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private void PlayGame_Clicked(object sender, EventArgs e)
        {
            GamePage gamePage = new GamePage();
        }


    }


}
