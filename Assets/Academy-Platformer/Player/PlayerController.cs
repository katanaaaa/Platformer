using System;
using Sounds;
using Object = UnityEngine.Object;

namespace Player
{
    public class PlayerController
    {
        public Action OnDisposed;
        
        private readonly SoundController _soundController;
        private readonly PlayerConfig _playerConfig;
        private PlayerView _playerView;
        private PlayerView.PlayerFactory _playerFactory;
        
        private readonly int _currentHealth;
        private readonly int _currentSpeed;
        private PlayerAnimator _playerAnimator;

        private const float DelayDestroyPlayer = 2f;

        public PlayerController(
            SoundController soundController,
            PlayerConfig playerConfig,
            PlayerSpawner playerSpawner,
            PlayerAnimator playerAnimator)
        {
            _soundController = soundController;
            _playerConfig = playerConfig;
            _playerAnimator = playerAnimator;

            _playerView = playerSpawner.Spawn();
            _currentHealth = _playerConfig.PlayerModel.Health;
            _currentSpeed = _playerConfig.PlayerModel.Speed;

            _playerAnimator.Spawn();
        }

        public void DestroyView(DG.Tweening.TweenCallback setEndWindow = null)
        {
            OnDisposed?.Invoke();

            _soundController.Stop();
            _soundController.Play(SoundName.GameOver);

            // _playerAnimator.Death(setEndWindow);
            
            Object.Destroy(_playerView.gameObject, DelayDestroyPlayer);
            _playerView = null;
        }
    }
}