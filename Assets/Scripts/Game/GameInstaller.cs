using UnityEngine;
using Utils.Screens;
using Utils.Services.Sound;
using Utils.Services.Sound.Pitch;
using Zenject;

namespace Game
{
    [CreateAssetMenu(menuName = "Installers/Game", fileName = nameof(GameInstaller))]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        [SerializeField] private SerializableSoundSettings soundSettings;
        [SerializeField] private SerializablePitchSettings pitchSettings;
        
        [SerializeField] private AudioSource audioSourcePrefab;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<ScreenService>()
                .AsSingle();
            
            Container
                .BindInterfacesTo<SerializableSoundSettings>()
                .FromInstance(soundSettings)
                .AsSingle();

            Container
                .BindInterfacesTo<SerializablePitchSettings>()
                .FromInstance(pitchSettings)
                .AsSingle();
            
            Container
                .BindInterfacesTo<PitchService>()
                .AsSingle();

            Container
                .BindInterfacesTo<SoundService>()
                .AsSingle();
            
            Container
                .BindMemoryPool<AudioSource, MemoryPool<AudioSource>>()
                .WithInitialSize(8)
                .WithMaxSize(16)
                .FromComponentInNewPrefab(audioSourcePrefab)
                .UnderTransformGroup(GameConstants.AudioPoolTransformGroup);
        }
    }
}