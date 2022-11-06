using UnityEngine;
using Zenject;

namespace Game.Obstacles
{
    public class ObstaclesInstaller : MonoInstaller<ObstaclesInstaller>
    {
        [SerializeField] private SerializableObstacleSettings obstacleSettings;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<SerializableObstacleSettings>()
                .FromInstance(obstacleSettings)
                .AsSingle();
            
            Container
                .BindMemoryPool<MonoObstacleView, ObstaclePool>()
                .WithInitialSize(2)
                .WithMaxSize(4)
                .FromComponentInNewPrefab(obstacleSettings.Prefab)
                .UnderTransformGroup(GameConstants.ObstaclesPoolTransformGroup);
            
            Container
                .BindInterfacesTo<ObstacleSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}