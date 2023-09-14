using UnityEngine;
using Zenject;

namespace Sounds
{
    public class SoundView : MonoBehaviour
    {
        public AudioSource AudioSource => audioSource;
        [SerializeField] private AudioSource audioSource;

        public class Pool : MonoMemoryPool<SoundView>
        {
            
        }
    }
}