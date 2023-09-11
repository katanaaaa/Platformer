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
            .Bind<SoundController>()
            .AsSingle();
        
        Container
            .Bind<PlayerController>()
            .AsSingle();
        
        Container
            .Bind<GameController>()
            .AsSingle();
        
        UIInstaller.Install(Container);

    }
}