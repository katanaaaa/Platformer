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
            .BindFactory<PlayerView, PlayerView.PlayerFactory>()
            .FromComponentInNewPrefabResource(ResourcesConst.PlayerView);

        Container
            .Bind<PlayerMovement>()
            .AsSingle()
            .NonLazy();
        
        Container
            .Bind<PlayerAnimator>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<PlayerController>()
            .AsSingle()
            .NonLazy();
    }
}