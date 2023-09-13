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
        private PlayerView.PlayerFactory _playerFactory;
        private int _currentHealth;
        private int _currentSpeed;

        public PlayerController(
            SoundController soundController,
            PlayerConfig playerConfig,
            PlayerView.PlayerFactory playerFactory,
            PlayerMovement playerMovement,
            PlayerAnimator playerAnimator)
        {
            _soundController = soundController;
            _playerConfig = playerConfig;
            _playerFactory = playerFactory;
            _playerMovement = playerMovement;
            _playerAnimator = playerAnimator;
        }

        private void CreatePlayer()
        {
            _playerView = _playerFactory.Create();
            
            _playerMovement.SetParameters(_playerView);
            _playerAnimator.SetParameters(_playerView);
            
            _currentHealth = _playerConfig.PlayerModel.Health;
            _currentSpeed = _playerConfig.PlayerModel.Speed;
        }
    }
}