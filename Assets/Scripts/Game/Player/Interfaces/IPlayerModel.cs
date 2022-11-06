using Abstractions.Interfaces;

namespace Game.Player.Interfaces
{
    public interface IPlayerModel : IResettable
    {
        void SetActive(bool active);
        
        void SetVerticalSpeed(float speed);
        void SetHorizontalSpeed(float speed);
        
        void MoveUp();
        void MoveDown();

        void IncrementAttempts();
        int GetAttemptsCount();
    }
}