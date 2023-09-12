using Player;
using Zenject;

public class PlayerInstaller : Installer<PlayerInstaller>
{
    public override void InstallBindings()
    {

        Container
            .Bind<PlayerConfig>()
            .FromScriptableObjectResource("PlayerConfig")
            .AsSingle();
        
        Container
            .Bind<PlayerHpController>()
            .AsSingle();
        
        Container
            .Bind<PlayerController>()
            .AsSingle()
            .NonLazy();
    }
}