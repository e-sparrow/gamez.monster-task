using System.Collections.Generic;
using Game.Level.Interfaces;
using Game.Screens.Start.Interfaces;

namespace Game.Screens.Start
{
    public readonly struct StartScreenArgument : IStartScreenArgument
    {
        public StartScreenArgument(IEnumerable<ILevelDifficultyInfo> difficulties)
        {
            Difficulties = difficulties;
        }

        public IEnumerable<ILevelDifficultyInfo> Difficulties
        {
            get;
        }
    }
}