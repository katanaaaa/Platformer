using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator
    {
        private PlayerView _playerView;

        private Sequence _sequenceSpawn;
        private Sequence _sequenceGetDamage;
        private Sequence _sequenceDeath;

        private Vector3 _startPositionPlayer;
        private Vector3 _endPositionPlayer;
        private readonly Camera _camera;

        private const float FactorOffsetX = 10f;
        private const float FactorPixelHeight = 5f;
        private const float FactorPixelWidth = 2f;
        private const float DurationSpawn = 5f;
        private const float DurationGetDamage = 0.1f;
        private const float DurationDeath = 1f;
        private const float DelaySpawn = 0.5f;
        private const float VisibilityAlphaGetDamage = 0f;
        private const float InvisibilityAlphaGetDamage = 1f;
        private const float IncreasePlayerDeath = 0.7f;
        private const float DecreasePlayerDeath = 0f;
        private const int NumberRepetitionsGetDamage = 5;

        public PlayerAnimator(Camera camera)
        {
            _camera = camera;
        }

        public void Start(PlayerView playerView)
        {
            _playerView = playerView;

            _startPositionPlayer = _camera.ScreenToWorldPoint(new Vector3(
                -FactorOffsetX * _playerView.SpriteRenderer.size.x,
                _camera.pixelHeight / FactorPixelHeight,
                -_camera.transform.position.z));
            _endPositionPlayer = _camera.ScreenToWorldPoint(new Vector3(
                _camera.pixelWidth / FactorPixelWidth,
                _camera.pixelHeight / FactorPixelHeight,
                -_camera.transform.position.z));
        }

        public void Spawn()
        {
            _playerView.transform.position = _startPositionPlayer;

            _sequenceSpawn?.Kill();

            _sequenceSpawn = DOTween.Sequence();

            _sequenceSpawn.Append(_playerView.transform
                .DOMove(_endPositionPlayer, DurationSpawn)
                .SetEase(Ease.OutBack)
                .SetDelay(DelaySpawn));
        }

        public void GetDamage()
        {
            _sequenceGetDamage?.Kill();

            _sequenceGetDamage = DOTween.Sequence();

            _sequenceGetDamage
                .Append(_playerView.SpriteRenderer.DOFade(VisibilityAlphaGetDamage, DurationGetDamage))
                .Append(_playerView.SpriteRenderer.DOFade(InvisibilityAlphaGetDamage, DurationGetDamage))
                .SetLoops(NumberRepetitionsGetDamage);
        }

        public void Death(TweenCallback setEndWindow = null)
        {
            _sequenceDeath?.Kill();

            _sequenceDeath = DOTween.Sequence();

            _sequenceDeath
                .Append(_playerView.transform.DOScale(IncreasePlayerDeath, DurationDeath).SetEase(Ease.InOutBounce))
                .Append(_playerView.transform.DOScale(DecreasePlayerDeath, DurationDeath).SetEase(Ease.InBounce)
                    .OnComplete(setEndWindow));
        }
    }
}