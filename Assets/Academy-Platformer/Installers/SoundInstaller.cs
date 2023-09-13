using Sounds;
using Zenject;

public class SoundInstaller : Installer<SoundInstaller>
{
    public override void InstallBindings()
    {
        Container
            .BindMemoryPool<SoundView, SoundView.SoundPool>()
            .WithInitialSize(5)
            .FromComponentInNewPrefabResource(ResourcesConst.SoundView)
            .UnderTransformGroup("SoundPool")
            .NonLazy();
        
        Container
            .Bind<SoundController>()
            .AsSingle()
            .NonLazy();
    }
}