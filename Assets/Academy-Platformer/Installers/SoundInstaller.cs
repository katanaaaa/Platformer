using Sounds;
using Zenject;

public class SoundInstaller : Installer<SoundInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<SoundConfig>()
            .FromScriptableObjectResource(ResourcesConst.SoundConfig)
            .AsSingle();
        
        Container
            .BindMemoryPool<SoundView, SoundView.SoundPool>()
            .WithInitialSize(5)
            .FromComponentInNewPrefabResource(ResourcesConst.SoundView)
            .UnderTransformGroup("SoundPool");

        Container
            .Bind<SoundPool>()
            .AsSingle();
        
        Container
            .Bind<SoundController>()
            .AsSingle()
            .NonLazy();
    }
}