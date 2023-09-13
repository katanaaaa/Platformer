using UnityEditor.UIElements;
using UnityEngine;
using Zenject;

namespace Sounds
{
    public class SoundView : MonoBehaviour
    {
        public AudioSource AudioSource => audioSource;
        [SerializeField] private AudioSource audioSource;
        private SoundConfig _soundConfig;

        [Inject]
        public void Construct(SoundConfig soundConfig)
        {
            _soundConfig = soundConfig;
        }
        
        public class SoundPool : MemoryPool<SoundName, SoundView>
        {
            protected override void Reinitialize(SoundName soundName, SoundView view)
            {
                view.audioSource.clip = view._soundConfig.Get(soundName);
                view.AudioSource.Play();
            }
        }
    }
}