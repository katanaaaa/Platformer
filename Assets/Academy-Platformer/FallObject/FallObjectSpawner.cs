using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace FallObject
{
    public class FallObjectSpawner : ITickable
    {
        private TickableManager _tickableManager;
        private readonly FallObjectView.Pool _fallObjectPool;
        private Vector2 _spawnPosition;
        private readonly float _positionY;
        private readonly float _minPositionX;
        private readonly float _maxPositionX;
        private readonly float _spawnPeriodMin;
        private readonly float _spawnPeriodMax;
        private readonly float _delayStartSpawn;
        private float _spawnPeriod;
        private int _typesCount;
        private float _timer;

        public FallObjectSpawner(
            TickableManager tickableManager,
            FallObjectConfig fallObjectConfig,
            FallObjectView.Pool fallObjectPool)
        {
            _tickableManager = tickableManager;
            _fallObjectPool = fallObjectPool;
            
            _positionY = fallObjectConfig.PositionY;
            _minPositionX = fallObjectConfig.MinPositionX;
            _maxPositionX = fallObjectConfig.MaxPositionX;
            _spawnPeriodMin = fallObjectConfig.SpawnPeriodMin;
            _spawnPeriodMax = fallObjectConfig.SpawnPeriodMax;
            _delayStartSpawn = fallObjectConfig.DelayStartSpawn;
            _spawnPosition = new Vector2(Random.Range(_minPositionX, _maxPositionX), _positionY);
            _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
            _typesCount = Enum.GetValues(typeof(FallObjectType)).Length;
        }

        public void Start()
        {
            _spawnPeriod = 6.5f;
            _tickableManager.Add(this);
        }

        public void Stop()
        {
            _tickableManager.Remove(this);
        }

        public void Tick()
        {
            _spawnPeriod -= Time.deltaTime;
            _timer += Time.deltaTime;

            if (_timer > _delayStartSpawn)
            {
                if (_spawnPeriod <= 0)
                {
                    SpawnNewObject();
                    _spawnPeriod = Random.Range(_spawnPeriodMin, _spawnPeriodMax);
                }
            }
        }

        private void SpawnNewObject()
        {
            var type = Random.Range(0, _typesCount);
            _spawnPosition.x = Random.Range(_minPositionX, _maxPositionX);
            var newObject = _fallObjectPool.Spawn((FallObjectType)type);
            newObject.gameObject.transform.position = _spawnPosition;
        }
    }
}