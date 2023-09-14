using Player;
using Zenject;

public class PlayerInstaller : Installer<PlayerInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<PlayerConfig>()
            .FromScriptableObjectResource(ResourcesConst.PlayerConfig)
            .AsSingle();
        
        Container
            .Bind<PlayerHp>()
            .AsSingle();

        Container
            .BindFactory<PlayerView, PlayerView.Factory>()
            .FromComponentInNewPrefabResource(ResourcesConst.PlayerView);
        
        Container
            .Bind<PlayerAnimator>()
            .AsSingle();

        Container
            .Bind<PlayerController>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<PlayerMovement>()
            .AsSingle()
            .NonLazy();
    }
}