using System;
using Game.Obstacles.Interfaces;
using UnityEngine;

namespace Game.Obstacles
{
    [Serializable]
    public class SerializableObstacleSettings : IObstacleSettings
    {
        [field: SerializeField]
        public MonoObstacleView Prefab
        {
            get;
            private set;
        }

        [field: SerializeField]
        public Vector2 StartPoint
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float Thickness
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float Gap
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float Range
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MinOffsetDifference
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float MaxOffsetDifference
        {
            get;
            private set;
        }
    }
}