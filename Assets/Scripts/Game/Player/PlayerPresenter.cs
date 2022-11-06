using System;
using System.Threading.Tasks;
using Abstractions.Interfaces;
using Cinemachine;
using Game.Level.Interfaces;
using Game.Obstacles.Interfaces;
using Game.Player.Interfaces;
using UnityEngine;
using Utils.Services.Sound.Enums;
using Utils.Services.Sound.Interfaces;
using Zenject;

namespace Game.Player
{
    public class PlayerPresenter : IInitializable, ILateDisposable, IFixedTickable
    {
        public PlayerPresenter
        (
            IPlayerModel model, 
            IPlayerView view, 
            IPlayerSettings settings, 
            
            ISoundService<ESoundType> soundService,
            IObstacleSystem obstacleSystem
        )
        {
            _model = model;
            _view = view;
            _settings = settings;

            _soundService = soundService;
            _obstacleSystem = obstacleSystem;
        }

        private readonly IPlayerModel _model;
        private readonly IPlayerView _view;
        private readonly IPlayerSettings _settings;

        private readonly ISoundService<ESoundType> _soundService;
        private readonly IObstacleSystem _obstacleSystem;
        
        private DateTime _startTime;

        private bool _isPlaying = false;
        
        public void Initialize()
        {
            GameSignals.GameStart.OnInvoke += Start;

            _view.OnCollide += Collide;
            _view.OnPass += Pass;
        }

        public void LateDispose()
        {
            _isPlaying = false;
            
            GameSignals.GameStart.OnInvoke -= Start;
            
            _view.OnCollide -= Collide;
            _view.OnPass -= Pass;
        }

        public void FixedTick()
        {
            if (!_isPlaying) return;
            
            if (Input.GetKey(_settings.UpKey))
            {
                _model.MoveUp();
            }
            else
            {
                _model.MoveDown();
            }
        }

        private void Start(ILevelDifficultyInfo difficulty)
        {
            _model.SetActive(true);
            _model.SetHorizontalSpeed(difficulty.Speed);
            _model.IncrementAttempts();
            
            _obstacleSystem.Update();

            Task.Run(UpdateVerticalSpeed);
            
            _startTime = DateTime.UtcNow;
            _isPlaying = true;
        }
        
        private void Collide()
        {
            _isPlaying = false;

            _soundService.PlayOneShot(ESoundType.GameOver);

            var time = DateTime.UtcNow - _startTime;
            GameSignals.GameOver.Invoke(time);
            
            _model.Reset();
            _obstacleSystem.Reset();
            _model.SetActive(false);
        }

        private void Pass()
        {
            _soundService.PlayOneShot(ESoundType.Pass);
            _obstacleSystem.Update();
        }

        private async Task UpdateVerticalSpeed()
        {
            var speed = _settings.InitialVerticalSpeed;
            _model.SetVerticalSpeed(speed);
            
            while (Application.isPlaying && _isPlaying)
            {
                var delay = TimeSpan.FromSeconds(_settings.VerticalSpeedIncreasePeriod);
                await Task.Delay(delay);
                
                speed += _settings.VerticalSpeedDelta;
                _model.SetVerticalSpeed(speed);
            }
        }
    }
}