using Cinemachine;
using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        [SerializeField] private SerializablePlayerSettings playerSettings;
        
        [SerializeField] private MonoPlayerView playerPrefab;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SerializablePlayerSettings>()
                .FromInstance(playerSettings)
                .AsSingle();

            var playerView = Instantiate(playerPrefab);
            var playerRigidbody = playerView.GetComponent<Rigidbody2D>();
            
            virtualCamera.Follow = playerView.transform;
            
            Container
                .BindInterfacesTo<PlayerModel>()
                .AsSingle()
                .WithArguments(playerRigidbody);

            Container
                .BindInterfacesTo<MonoPlayerView>()
                .FromInstance(playerView)
                .AsSingle();

            Container
                .BindInterfacesTo<PlayerPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}