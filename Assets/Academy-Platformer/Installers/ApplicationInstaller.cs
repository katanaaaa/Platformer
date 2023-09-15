using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<Camera>()
            .FromComponentInNewPrefabResource(ResourcesConst.MainCamera)
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<InputController>()
            .AsSingle()
            .NonLazy();

        SoundInstaller.Install(Container);
        UIInstaller.Install(Container);
        PlayerInstaller.Install(Container);
        
        Container
            .Bind<ScoreCounter>()
            .AsSingle();
        
        Container
            .BindInterfacesAndSelfTo<GameController>()
            .AsSingle()
            .NonLazy();
    }
}