using System.Linq;
using UnityEngine;
using Utils.Services.Sound.Enums;
using Utils.Services.Sound.Interfaces;
using Utils.Services.Sound.Pitch.Interfaces;
using Zenject;

namespace Utils.Services.Sound
{
    public class SoundService : SoundServiceBase<ESoundType>
    {
        public SoundService(MemoryPool<AudioSource> audioSourcePool, ISoundSettings settings, IPitchService pitchService)
            : base(audioSourcePool)
        {
            _settings = settings;
            _pitchService = pitchService;
        }

        private readonly ISoundSettings _settings;
        private readonly IPitchService _pitchService;

        protected override AudioClip GetClipByKey(ESoundType key)
        {
            var all = _settings.Sources.Where(value => value.Type == key);
            var array = all.ToArray();
            
            var index = Random.Range(0, array.Length);
            var random = array[index];

            var result = random.Clip;
            return result;
        }

        protected override float GetPitchByKey(ESoundType key)
        {
            var result = _pitchService.GetCurrentPitch();
            return result;
        }
    }
}