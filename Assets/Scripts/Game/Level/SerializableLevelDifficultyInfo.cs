using System;
using Game.Level.Interfaces;
using UnityEngine;

namespace Game.Level
{
    [Serializable]
    public class SerializableLevelDifficultyInfo : ILevelDifficultyInfo
    {
        [field: SerializeField]
        public string Name
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float Speed
        {
            get;
            private set;
        }
    }
}