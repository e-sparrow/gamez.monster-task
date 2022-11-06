using System;
using UnityEngine;
using Utils.Services.Sound.Enums;

namespace Utils.Services.Sound
{
    [Serializable]
    public struct SoundSource
    {
        [field: SerializeField]
        public ESoundType Type
        {
            get;
            private set;
        }

        [field: SerializeField]
        public AudioClip Clip
        {
            get;
            private set;
        }
    }
}