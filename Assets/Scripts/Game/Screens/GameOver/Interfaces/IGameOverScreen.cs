using System;
using Utils.Screens.Interfaces;

namespace Game.Screens.GameOver.Interfaces
{
    public interface IGameOverScreen : IScreen<IGameOverScreenArgument>
    {
        event Action OnRequestChangeDifficulty;
        event Action OnRequestTryAgain;
    }
}