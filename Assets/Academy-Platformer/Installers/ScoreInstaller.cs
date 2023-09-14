using Zenject;

public class ScoreInstaller : Installer<ScoreInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<ScoreCounter>()
            .AsSingle();
    }
}