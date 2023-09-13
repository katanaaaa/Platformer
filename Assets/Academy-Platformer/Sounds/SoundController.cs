namespace Sounds
{
    public class SoundController
    {
        private readonly SoundPool _soundPool;

        public SoundController()
        {
            
        }

        public void Play(SoundName soundName, float volume = 1, bool loop = false)
        {
            SwitchOff();

            var sound = _soundPool.TakeFromPool(soundName, volume, loop);
            sound.AudioSource.Play();
        }

        private void SwitchOff()
        {
            _soundPool.DisableCompletedSounds();
        }

        public void Stop()
        {
            _soundPool.MuteSound();
        }
    }
}