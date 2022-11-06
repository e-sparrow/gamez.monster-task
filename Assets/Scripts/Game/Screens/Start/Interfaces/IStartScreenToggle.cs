using Game.Level.Interfaces;

namespace Game.Screens.Start.Interfaces
{
    public interface IStartScreenToggle
    {
        void Initialize(ILevelDifficultyInfo difficulty);
    }
}