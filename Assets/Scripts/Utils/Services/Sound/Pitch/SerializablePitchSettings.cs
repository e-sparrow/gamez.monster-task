using System;
using UnityEngine;
using Utils.Services.Sound.Pitch.Interfaces;

namespace Utils.Services.Sound.Pitch
{
    [Serializable]
    public class SerializablePitchSettings : IPitchSettings
    {
        [field: SerializeField]
        public float Value
        {
            get; 
            private set;
        }

        [field: SerializeField]
        public float Step
        {
            get; 
            private set;
        }

        [field: SerializeField]
        public float Time
        {
            get;
            private set;
        }

        [field: SerializeField]
        public int StepsCount
        {
            get; 
            private set;
        }
    }
}