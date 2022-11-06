using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.Services.Sound.Interfaces;

namespace Utils.Services.Sound
{
    [Serializable]
    public class SerializableSoundSettings : ISoundSettings
    {
        [NonReorderable]
        [SerializeField] private SoundSource[] sources;

        public IEnumerable<SoundSource> Sources => sources;
    }
}