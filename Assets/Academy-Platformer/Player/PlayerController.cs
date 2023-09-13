using Sounds;

namespace Player
{
    public class PlayerController
    {
        private readonly SoundController _soundController;
        private readonly PlayerConfig _playerConfig;
        private PlayerView _playerView;
        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;
        private PlayerView.Factory _playerFactory;

        public PlayerController(
            SoundController soundController,
            PlayerConfig playerConfig,
            PlayerView.Factory playerFactory,
            PlayerMovement playerMovement,
            PlayerAnimator playerAnimator)
        {
            _soundController = soundController;
            _playerConfig = playerConfig;
            _playerFactory = playerFactory;
            _playerMovement = playerMovement;
            _playerAnimator = playerAnimator;
        }

        private void Spawn()
        {
            _playerView = _playerFactory.Create();
            
            _playerMovement.SetParameters(_playerView);
            _playerAnimator.SetParameters(_playerView);
        }
    }
}