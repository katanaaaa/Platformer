using Sounds;
using Zenject;

public class SoundInstaller : Installer<SoundInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<SoundController>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<SoundPool>()
            .AsSingle()
            .NonLazy();
    }
}
