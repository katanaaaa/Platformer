using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : IDisposable
    {
        private readonly InputController _inputController;
        private PlayerView _playerView;

        private const float Speed = 5f;

        private readonly Vector3 _leftPointStop;
        private readonly Vector3 _rightPointStop;
        
        private readonly float _step;
        private readonly DisposableManager _disposableManager;

        public PlayerMovement(
            InputController inputController,
            Camera camera,
            DisposableManager disposableManager)
        {
            _inputController = inputController;
            _disposableManager = disposableManager;

            _step = Speed * Time.deltaTime;
            _leftPointStop = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
            _rightPointStop = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f));
            
        }

        public void SetParameters(PlayerView playerView)
        {
            _playerView = playerView;
            _inputController.OnLeftEvent += MoveLeft;
            _inputController.OnRightEvent += MoveRight;
            _disposableManager.Add(this);
        }
        
        public void Dispose()
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