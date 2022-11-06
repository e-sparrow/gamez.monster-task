using System;
using Game.Player.Interfaces;
using UnityEngine;

namespace Game.Player
{
    [Serializable]
    public class SerializablePlayerSettings : IPlayerSettings
    {
        [field: SerializeField]
        public KeyCode UpKey
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float InitialVerticalSpeed
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float VerticalSpeedIncreasePeriod
        {
            get;
            private set;
        }

        [field: SerializeField]
        public float VerticalSpeedDelta
        {
            get;
            private set;
        }
    }
}