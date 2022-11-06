using System;
using System.Collections.Generic;
using Game.Level;
using Game.Level.Interfaces;
using Game.Screens.Start.Interfaces;
using UnityEngine;

namespace Game.Screens.Start
{
    [Serializable]
    public class SerializableStartScreenArgument : IStartScreenArgument
    {
        [SerializeField] private List<SerializableLevelDifficultyInfo> difficulties;
        public IEnumerable<ILevelDifficultyInfo> Difficulties => difficulties;
    }
}