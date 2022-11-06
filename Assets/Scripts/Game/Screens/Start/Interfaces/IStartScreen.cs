using System;
using Game.Level.Interfaces;
using Utils.Screens.Interfaces;

namespace Game.Screens.Start.Interfaces
{
    public interface IStartScreen : IScreen<IStartScreenArgument>
    {
        event Action<ILevelDifficultyInfo> OnStartClicked;
    }
}