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

        
        SoundInstaller.Install(Container);
        UIInstaller.Install(Container);
        
        Container
            .Bind<InputController>()
            .AsSingle()
            .NonLazy();
        
        PlayerInstaller.Install(Container);
        
        Container
            .Bind<GameController>()
            .AsSingle();
    }
}