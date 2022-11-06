using System;
using Game.Level.Interfaces;
using Game.Obstacles.Interfaces;
using Zenject;

namespace Game.Obstacles
{
    public class ObstacleSystem : IObstacleSystem, IInitializable, ILateDisposable
    {
        public ObstacleSystem(ObstaclePool pool)
        {
            _pool = pool;
        }

        private const int StartCount = 2;

        private readonly ObstaclePool _pool;

        public void Initialize()
        {
            GameSignals.GameStart.OnInvoke += Start;
            GameSignals.GameOver.OnInvoke += Clear;
        }

        public void LateDispose()
        {
            GameSignals.GameStart.OnInvoke -= Start;
            GameSignals.GameOver.OnInvoke -= Clear;
        }

        public void Update()
        {
            _pool.Spawn();
        }

        private void Start(ILevelDifficultyInfo _)
        {
            for (var i = 0; i < StartCount; i++)
            {
                _pool.Spawn();
            }
        }

        private void Clear(TimeSpan _)
        {
            _pool.Clear();
        }

        public void Reset()
        {
            _pool.Reset();
            _pool.Clear();
        }
    }
}