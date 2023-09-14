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

        public struct SoundProtocol
        {
            public SoundName Name;
            public float Volume;
            public bool Loop;

            public SoundProtocol(SoundName soundName, float volume, bool loop)
            {
                Name = soundName;
                Volume = volume;
                Loop = loop;
            }
        }
        
        public class Pool : MonoMemoryPool<SoundProtocol ,SoundView>
        {
            protected override void Reinitialize(SoundProtocol soundProtocol, SoundView soundView)
            {
                var source = soundView.AudioSource;
                source.clip = soundView._soundConfig.Get(soundProtocol.Name);
                source.volume = soundProtocol.Volume;
                source.loop = soundProtocol.Loop;
            }
        }
    }
}