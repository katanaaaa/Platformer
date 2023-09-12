using Sounds;
using Zenject;

public class SoundInstaller : Installer<SoundInstaller>
{
    public override void InstallBindings()
    {
        Container
            .Bind<SoundPool>()
            .AsSingle();
        
        Container
            .Bind<SoundController>()
            .AsSingle()
            .NonLazy();
    }
}