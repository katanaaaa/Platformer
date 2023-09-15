using System;
using Sounds;
using UI.HUD;
using Object = UnityEngine.Object;

namespace Player
{
    public class PlayerController
    {
        public Action OnDisposed;

        public PlayerHp PlayerHp => _playerHp;

        private const float DelayDestroyPlayer = 2f;

        private readonly SoundController _soundController;
        private readonly PlayerConfig _playerConfig;
        private readonly PlayerHp _playerHp;
        private PlayerView _playerView;
        private PlayerView.Factory _playerFactory;
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;

        public PlayerController(
            SoundController soundController,
            HUDWindowController hudWindowController,
            PlayerConfig playerConfig,
            PlayerView.Factory playerFactory,
            PlayerHp playerHp,
            PlayerMovement playerMovement,
            PlayerAnimator playerAnimator)
        {
            _soundController = soundController;
            _playerConfig = playerConfig;
            _playerFactory = playerFactory;
            _playerMovement = playerMovement;
            _playerAnimator = playerAnimator;
            _playerHp = playerHp;

            _playerHp.OnHealthChanged += hudWindowController.ChangeHealthPoint;
        }

        public void Spawn()
        {
            _playerView = _playerFactory.Create();
            _playerMovement.StartMoving(_playerView);
            _playerAnimator.Start(_playerView);
        }

        public void DestroyView(DG.Tweening.TweenCallback setEndWindow = null)
        {
            OnDisposed?.Invoke();

            _soundController.Stop();
            _soundController.Play(SoundName.GameOver);

            _playerMovement.StopMoving();
            _playerAnimator.Death(setEndWindow);

            Object.Destroy(_playerView.gameObject, DelayDestroyPlayer);
            _playerView = null;
        }
    }
}