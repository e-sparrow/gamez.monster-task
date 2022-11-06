using Utils.Screens.Interfaces;

namespace Utils.Screens
{
    public class ScreenService : IScreenService
    {
        private IHiddable _activeScreen;
        
        public void ShowScreen(IScreen screen)
        {
            _activeScreen?.Hide();
            _activeScreen = screen;
            
            screen.Show();
        }

        public void ShowScreen<TArgument>(IScreen<TArgument> screen, TArgument argument)
        {
            _activeScreen?.Hide();
            _activeScreen = screen;
            
            screen.Show(argument);
        }

        public void Hide()
        {
            _activeScreen.Hide();
            _activeScreen = null;
        }
    }
}