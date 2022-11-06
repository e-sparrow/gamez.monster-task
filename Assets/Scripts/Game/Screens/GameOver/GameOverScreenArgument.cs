using Game.Screens.GameOver.Interfaces;

namespace Game.Screens.GameOver
{
    public readonly struct GameOverScreenArgument : IGameOverScreenArgument
    {
        public GameOverScreenArgument(float attemptTime, int attemptsCount)
        {
            AttemptTime = attemptTime;
            AttemptsCount = attemptsCount;
        }

        public float AttemptTime
        {
            get;
        }

        public int AttemptsCount
        {
            get;
        }
    }
}