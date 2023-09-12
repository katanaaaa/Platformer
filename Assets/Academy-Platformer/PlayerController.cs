namespace Player
{
    public class PlayerController
    {
        private readonly PlayerConfig _playerConfig;
        private int _currentHealth;
        private int _currentSpeed;

        public PlayerController(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
        }

        public PlayerView Create()
        {
            var model = _playerConfig.PlayerModel;
            _currentHealth = model.Health;
            _currentSpeed = model.Speed;
            
            
            return null;
        }
    }
}