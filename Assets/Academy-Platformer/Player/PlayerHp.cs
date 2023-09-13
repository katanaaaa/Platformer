using System;
using Sounds;

namespace Player
{
    public class PlayerHp
    {
        public Action<float> OnHealthChanged;
        public Action OnZeroHealth;

        private SoundController _soundController;

        private float _health;

        public PlayerHp(PlayerConfig playerConfig, SoundController soundController)
        {
            _health = playerConfig.PlayerModel.Health;
            _soundController = soundController;
        }
        
        private void ReduceHealth(float damage)
        {
            _health -= damage;

            _soundController.Play(SoundName.GetDamage);
            
            OnHealthChanged?.Invoke(_health);
            if (_health <= 0)
            {
                OnZeroHealth?.Invoke();
            }
        }
    }
}