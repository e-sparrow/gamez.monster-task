using UnityEngine;

namespace Game.Obstacles.Interfaces
{
    public interface IObstacleView
    {
        void SetThickness(float value);
        void SetGap(float value);
        void SetOffset(float offset);
        void SetPosition(Vector2 position);
    }
}