using Zenject;

namespace Player
{
    public class PlayerSpawner
    {
        private readonly PlayerView.PlayerFactory _playerFactory;

        public PlayerSpawner(PlayerView.PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public PlayerView Spawn()
        {
            return _playerFactory.Create();
        }
    }
}