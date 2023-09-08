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


    private void InstallCamera()
    {
        Container
            .Bind<Camera>()
            .FromComponentInNewPrefabResource(ResourcesConst.MainCamera)
            .AsSingle()
            .NonLazy();
    }
    private void InstallMisc()
    {
        Container
            .Bind<GameController>()
            .AsSingle()
            .NonLazy();
    }
}