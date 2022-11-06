using System;
using System.Threading.Tasks;
using UnityEngine;
using Utils.Services.Sound.Interfaces;
using Zenject;

namespace Utils.Services.Sound
{
    public abstract class SoundServiceBase<TKey> : ISoundService<TKey>
    {
        protected SoundServiceBase(MemoryPool<AudioSource> audioSourcePool)
        {
            _audioSourcePool = audioSourcePool;
        }

        private readonly MemoryPool<AudioSource> _audioSourcePool;

        protected abstract AudioClip GetClipByKey(TKey key);
        protected abstract float GetPitchByKey(TKey key);

        public async void PlayOneShot(TKey key)
        {
            var source = _audioSourcePool.Spawn();
            var value = GetClipByKey(key);
            var pitch = GetPitchByKey(key);

            source.pitch = pitch;
            source.PlayOneShot(value);

            var delay = TimeSpan.FromSeconds(value.length);
            await Task.Delay(delay);

            if (!Application.isPlaying) return;

            _audioSourcePool.Despawn(source);
        }
    }
}