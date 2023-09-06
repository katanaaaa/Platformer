using UI.UIService;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameController>().AsSingle().NonLazy();
        
        Container.Bind<UnityEngine.Camera>()
            .FromComponentInNewPrefabResource(ResourcesConst.MainCamera)
            .AsSingle()
            .NonLazy();
        
        Container.Bind<IUIService>().To<UIService>().AsSingle();
    }
}