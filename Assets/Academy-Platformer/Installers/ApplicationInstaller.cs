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

        UIInstaller.Install(Container);

        Container
            .Bind<GameController>()
            .AsSingle();
    }
}

public class UIInstaller : Installer<UIInstaller>
{
    public override void InstallBindings()
    {

    }
}