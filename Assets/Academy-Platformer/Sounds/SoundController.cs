using System.Collections.Generic;

namespace Sounds
{
    public class SoundController
    {
        private SoundConfig _soundConfig;
        private List<SoundView> _soundViews = new();
        private readonly SoundView.Pool _soundPool;

        public SoundController(SoundConfig soundConfig, SoundView.Pool soundPool)
        {
            _soundConfig = soundConfig;
            _soundPool = soundPool;
        }
        
        public void Play(SoundName soundName, float volume = 1, bool loop = false)
        {
            DisableCompletedSounds();

            var sound = _soundPool.Spawn();
            var source = sound.AudioSource;
            
            source.clip = _soundConfig.Get(soundName);
            source.volume = volume;
            source.loop = loop;
            
            sound.AudioSource.Play();
        }
        
        private void DisableCompletedSounds()
        {
            foreach (var soundView in _soundViews)
            {
                if (!soundView.AudioSource.isPlaying)
                {
                    soundView.AudioSource.clip = null;
                    _soundViews.Remove(soundView);
                    _soundPool.Despawn(soundView);
                }
            }
        }

        public void Stop()
        {
            foreach (var soundView in _soundViews)
            {
                soundView.AudioSource.clip = null;
                _soundViews.Remove(soundView);
                _soundPool.Despawn(soundView);
            }
        }
    }
}