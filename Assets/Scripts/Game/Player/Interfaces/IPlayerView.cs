using System;

namespace Game.Player.Interfaces
{
    public interface IPlayerView
    {
        event Action OnCollide;
        event Action OnPass;
    }
}