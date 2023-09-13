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
        InputInstaller.Install(Container);
        // PlayerInstaller.Install(Container);
        MiscInstaller.Install(Container);
    }
}