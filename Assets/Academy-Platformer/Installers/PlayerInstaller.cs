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
            .Bind<PlayerSpawner>()
            .AsSingle();
        
        Container
            .BindFactory<PlayerView, PlayerView.PlayerFactory>()
            .FromComponentInNewPrefabResource(ResourcesConst.PlayerView);
        
        Container
            .Bind<PlayerAnimator>()
            .AsSingle();

        Container
            .Bind<PlayerMovement>()
            .AsSingle();

        Container
            .Bind<PlayerController>()
            .AsSingle()
            .NonLazy();
    }
}