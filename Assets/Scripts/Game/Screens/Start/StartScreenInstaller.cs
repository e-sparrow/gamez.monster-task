using UnityEngine;
using Zenject;

namespace Game.Screens.Start
{
    public class StartScreenInstaller : MonoInstaller<StartScreenInstaller>
    {
        [SerializeField] private MonoStartScreen screen;
        [SerializeField] private SerializableStartScreenArgument argument;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<StartScreenPresenter>()
                .AsSingle()
                .WithArguments(screen, argument)
                .NonLazy();
        }
    }
}