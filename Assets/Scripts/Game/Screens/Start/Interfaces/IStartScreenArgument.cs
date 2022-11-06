using System.Collections.Generic;
using Game.Level.Interfaces;

namespace Game.Screens.Start.Interfaces
{
    public interface IStartScreenArgument
    {
        IEnumerable<ILevelDifficultyInfo> Difficulties
        {
            get;
        }
    }
}