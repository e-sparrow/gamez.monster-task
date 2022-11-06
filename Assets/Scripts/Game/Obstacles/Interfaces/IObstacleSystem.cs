using Abstractions.Interfaces;

namespace Game.Obstacles.Interfaces
{
    public interface IObstacleSystem : IResettable
    {
        void Update();
    }
}