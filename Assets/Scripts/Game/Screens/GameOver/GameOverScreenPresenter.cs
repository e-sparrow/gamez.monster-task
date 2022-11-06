using System;
using Game.Level.Interfaces;
using Game.Player.Interfaces;
using Game.Screens.GameOver.Interfaces;
using Utils.Screens.Interfaces;
using Zenject;

namespace Game.Screens.GameOver
{
    public class GameOverScreenPresenter : IInitializable, ILateDisposable
    {
        public GameOverScreenPresenter(IScreenService screenService, IGameOverScreen screen, IPlayerModel playerModel)
        {
            _screenService = screenService;
            _screen = screen;

            _playerModel = playerModel;
        }

        private readonly IScreenService _screenService;
        private readonly IGameOverScreen _screen;

        private readonly IPlayerModel _playerModel;

        private ILevelDifficultyInfo _tempDifficulty;
        
        public void Initialize()
        {
            GameSignals.GameOver.OnInvoke += GameOver;
            GameSignals.GameStart.OnInvoke += Start;

            _screen.OnRequestChangeDifficulty += ChangeDifficulty;
            _screen.OnRequestTryAgain += TryAgain;
        }

        public void LateDispose()
        {
            GameSignals.GameOver.OnInvoke -= GameOver;
            GameSignals.GameStart.OnInvoke -= Start;

            _screen.OnRequestChangeDifficulty += ChangeDifficulty;
            _screen.OnRequestTryAgain += TryAgain;
        }

        private void GameOver(TimeSpan time)
        {
            var count = _playerModel.GetAttemptsCount();
            var argument = new GameOverScreenArgument((float) time.TotalSeconds, count);
            
            _screenService.ShowScreen(_screen, argument);
        }

        private void Start(ILevelDifficultyInfo difficulty)
        {
            _tempDifficulty = difficulty;
        }

        private void ChangeDifficulty()
        {
            GameSignals.OpenStartScreen.Invoke();
        }

        private void TryAgain()
        {
            _screenService.Hide();
            GameSignals.GameStart.Invoke(_tempDifficulty);
        }
    }
}