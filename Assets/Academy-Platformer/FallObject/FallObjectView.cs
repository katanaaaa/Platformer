using System;
using UnityEngine;
using Zenject;

namespace FallObject
{
    public class FallObjectView : MonoBehaviour
    {
        public event Action<Collision2D> OnCollitionEnter2DNotify;
        public SpriteRenderer SpriteRenderer => spriteRenderer;
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private FallObjectConfig _fallObjectConfig;

        [Inject]
        public void Construct(FallObjectConfig fallObjectConfig)
        {
            _fallObjectConfig = fallObjectConfig;
        }

        private void OnCollitionEnter2D(Collision2D other)
        {
            OnCollitionEnter2DNotify?.Invoke(other);
        }
        
        public class Pool : MonoMemoryPool<FallObjectType, FallObjectView>
        {
            protected override void Reinitialize(FallObjectType type, FallObjectView view)
            {
                var model = view._fallObjectConfig.Get(type);
                view.SpriteRenderer.sprite = model.ObjectSprite;
                view.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                
                var controller = new FallObjectController(view, model);
            }
        }
    }
}