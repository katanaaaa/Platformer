using FallObject;
using Zenject;

public class FallObjectInstaller : Installer<FallObjectInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<FallObjectConfig>()
            .FromScriptableObjectResource(ResourcesConst.FallObjectConfig)
            .AsSingle();

        Container
            .BindMemoryPool<FallObjectView, FallObjectView.Pool>()
            .WithInitialSize(5)
            .FromComponentInNewPrefabResource(ResourcesConst.FallObjectView)
            .UnderTransformGroup("FallObjects");

        Container
            .Bind<FallObjectSpawner>()
            .AsSingle()
            .NonLazy();
    }
}