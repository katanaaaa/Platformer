using System.Collections.Generic;

namespace Sounds
{
    public class SoundController
    {
        private readonly SoundView.SoundPool _soundPool;
        private List<SoundView> _soundViews = new();
        private SoundConfig _soundConfig;
        
        public SoundController(SoundConfig soundConfig)
        {
            _soundConfig = soundConfig;
        }
        
        public void Play(SoundName soundName, float volume = 1, bool loop = false)
        {
            // SwitchOff();

            var sound = _soundPool.Spawn(soundName);
            _soundViews.Add(sound);
        }
        
        // private void SwitchOff()
        // {
        //     _soundPool.DisableCompletedSounds();
        // }
        
        // public void Stop()
        // {
        //     _soundPool.MuteSound();
        // }
    }
}