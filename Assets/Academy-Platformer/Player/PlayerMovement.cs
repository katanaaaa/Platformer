using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement
    {
        private readonly InputController _inputController;
        private readonly TickableManager _tickableManager;
        private PlayerView _playerView;

        private const float Speed = 5f;

        private readonly Vector3 _leftPointStop;
        private readonly Vector3 _rightPointStop;
        
        private readonly float _step;
        private readonly PlayerController _playerController;

        public PlayerMovement(
            InputController inputController,
            Camera camera,
            TickableManager tickableManager,
            PlayerController playerController)
        {
            _inputController = inputController;
            _tickableManager = tickableManager;
            _playerController = playerController;

            _step = Speed * Time.deltaTime;
            _leftPointStop = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
            _rightPointStop = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));
        }

        public void StartMoving()
        {
            _playerView = _playerController.GetPlayerView();
            _inputController.OnLeftEvent += MoveLeft;
            _inputController.OnRightEvent += MoveRight;
        }

        public void StopMoving()
        {
            _inputController.OnLeftEvent -= MoveLeft;
            _inputController.OnRightEvent -= MoveRight;
        }

        private void MoveLeft()
        {
            if (_playerView.transform.position.x > _leftPointStop.x + _playerView.SpriteRenderer.bounds.size.x / 2f)
            {
                var position = _playerView.transform.position;
                var target = position + Vector3.left;
                _playerView.transform.position = Vector3.MoveTowards(position, target, _step);
            }
        }

        private void MoveRight()
        {
            if (_playerView.transform.position.x < _rightPointStop.x - _playerView.SpriteRenderer.bounds.size.x / 2f)
            {
                var position = _playerView.transform.position;
                var target = position + Vector3.right;
                _playerView.transform.position = Vector3.MoveTowards(position, target, _step);
            }
        }
    }
}