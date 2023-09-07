using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallCamera();
        InstallMisc();
        SoundInstaller.Install(Container);
        UIInstaller.Install(Container);
    }

    private void InstallMisc()
    {
        Container
            .BindInterfacesAndSelfTo<GameController>()
            .AsSingle()
            .NonLazy();
    }

    private void InstallCamera()
    {
        Container
            .Bind<Camera>()
            .FromComponentInNewPrefabResource(ResourcesConst.MainCamera)
            .AsSingle()
            .NonLazy();
    }
}