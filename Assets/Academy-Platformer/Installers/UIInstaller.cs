using UI.HUD;
using UI.UIService;
using UI.UIWindows;
using Zenject;

public class UIInstaller : Installer<UIInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<IUIRoot>()
            .To<UIRoot>()
            .FromComponentInNewPrefabResource(ResourcesConst.UIRoot)
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<IUIService>()
            .To<UIService>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<UIMainMenuController>()
            .AsSingle();
        
        Container
            .Bind<UIGameWindowController>()
            .AsSingle();

        Container
            .Bind<UIEndGameWindowController>()
            .AsSingle();

        Container
            .Bind<HUDWindowController>()
            .AsSingle();
    }
}