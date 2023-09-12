using Zenject;

public class MiscInstaller : Installer<MiscInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<GameController>()
            .AsSingle();
    }
}