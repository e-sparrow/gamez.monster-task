using Game.Level.Interfaces;
using Game.Screens.Start.Interfaces;
using Utils.Screens.Interfaces;
using Zenject;

namespace Game.Screens.Start
{
    public class StartScreenPresenter : IInitializable, ILateDisposable
    {
        public StartScreenPresenter
        (
            IScreenService screenService, 
            IStartScreen screen, 
            IStartScreenArgument argument
        )
        {
            _screenService = screenService;
            _screen = screen;
            _argument = argument;
        }

        private readonly IScreenService _screenService;
        private readonly IStartScreen _screen;
        private readonly IStartScreenArgument _argument;
        
        public void Initialize()
        {
            GameSignals.OpenStartScreen.OnInvoke += Show;

            Show();
            _screen.OnStartClicked += Start;
        }

        public void LateDispose()
        {
            GameSignals.OpenStartScreen.OnInvoke -= Show;
            
            _screen.OnStartClicked -= Start;
        }

        private void Show()
        {
            _screenService.ShowScreen(_screen, _argument);
        }

        private void Start(ILevelDifficultyInfo difficulty)
        {
            _screenService.Hide();
            GameSignals.GameStart.Invoke(difficulty);
        }
    }
}