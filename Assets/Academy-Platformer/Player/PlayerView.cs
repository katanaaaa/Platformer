using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour, IDisposable
    {
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
       
        
        public void Dispose()
        {
         //todo logic of despawn
        }
        public class Factory : PlaceholderFactory<PlayerView>
        { }

    }
}