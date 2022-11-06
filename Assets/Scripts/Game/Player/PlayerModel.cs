using Game.Player.Interfaces;
using UnityEngine;

namespace Game.Player
{
    public class PlayerModel : IPlayerModel
    {
        public PlayerModel(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;

            if (PlayerPrefs.HasKey(GameConstants.AttemptsKey))
            {
                _attemptsCount = PlayerPrefs.GetInt(GameConstants.AttemptsKey);
            }
        }

        private readonly Rigidbody2D _rigidbody;

        private float _verticalSpeed = 0f;
        private float _horizontalSpeed = 0f;

        private int _attemptsCount = 0;

        public void SetActive(bool active)
        {
            _rigidbody.simulated = active;
        }

        public void SetVerticalSpeed(float speed)
        {
            _verticalSpeed = speed;
        }

        public void SetHorizontalSpeed(float speed)
        {
            _horizontalSpeed = speed;
        }

        public void MoveUp()
        {
            var velocity = new Vector2(_horizontalSpeed, _verticalSpeed) * Time.fixedDeltaTime;
            _rigidbody.velocity = velocity;
        }

        public void MoveDown()
        {
            var velocity = new Vector2(_horizontalSpeed, -_verticalSpeed) * Time.fixedDeltaTime;
            _rigidbody.velocity = velocity;
        }

        public void IncrementAttempts()
        {
            _attemptsCount++;
            PlayerPrefs.SetInt(GameConstants.AttemptsKey, _attemptsCount);
        }

        public int GetAttemptsCount()
        {
            return _attemptsCount;
        }

        public void Reset()
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.transform.position = Vector2.zero;
        }
    }
}