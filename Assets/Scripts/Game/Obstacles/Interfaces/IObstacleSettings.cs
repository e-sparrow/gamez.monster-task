using UnityEngine;

namespace Game.Obstacles.Interfaces
{
    public interface IObstacleSettings
    {
        MonoObstacleView Prefab
        {
            get;
        }

        Vector2 StartPoint
        {
            get;
        }
        
        float Thickness
        {
            get;
        }

        float Gap
        {
            get;
        }

        float Range
        {
            get;
        }

        float MinOffsetDifference
        {
            get;
        }

        float MaxOffsetDifference
        {
            get;
        }
    }
}