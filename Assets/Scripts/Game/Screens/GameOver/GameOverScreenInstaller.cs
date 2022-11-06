using UnityEngine;
using Zenject;

namespace Game.Screens.GameOver
{
    public class GameOverScreenInstaller : MonoInstaller<GameOverScreenInstaller>
    {
        [SerializeField] private MonoGameOverScreen screen;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameOverScreenPresenter>()
                .AsSingle()
                .WithArguments(screen);
        }
    }
}