using System;
using Game.Player.Interfaces;
using UnityEngine;

namespace Game.Player
{
    [Serializable]
    public class SerializablePlayerData : IPlayerData
    {
        [field: SerializeField]
        public int AttemptsCount
        {
            get;
            private set;
        }
    }
}