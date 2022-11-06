using System.Collections.Generic;
using Game.Obstacles.Interfaces;
using UnityEngine;
using Zenject;

namespace Game.Obstacles
{
    public class ObstaclePool : MemoryPool<MonoObstacleView>, IObstaclePool
    {
        public ObstaclePool(IObstacleSettings settings)
        {
            _settings = settings;
        }

        private readonly IObstacleSettings _settings;

        private int _current = 0;
        private float _previousOffset = 0f;

        protected override void OnCreated(MonoObstacleView item)
        {
            OnDespawned(item);
        }

        protected override void OnSpawned(MonoObstacleView item)
        {
            item.gameObject.SetActive(true);
            
            var position = _settings.StartPoint + Vector2.right * _settings.Range * _current;
            item.SetPosition(position);

            var random = Mathf.Abs(Random.Range(_settings.MinOffsetDifference, _settings.MaxOffsetDifference));
            var offset = _previousOffset > 0 ? -random : random;
            item.SetOffset(offset);
            
            item.SetGap(_settings.Gap);
            item.SetThickness(_settings.Thickness);

            _current++;
            _previousOffset = offset;
        }

        protected override void OnDespawned(MonoObstacleView item)
        {
            item.gameObject.SetActive(false);
        }

        public void Reset()
        {
            _current = 0;
            _previousOffset = 0f;
        }
    }
}