using UnityEngine;

namespace Game.Player.Interfaces
{
    public interface IPlayerSettings
    {
        KeyCode UpKey
        {
            get;
        }

        float InitialVerticalSpeed
        {
            get;
        }
        
        float VerticalSpeedIncreasePeriod
        {
            get;
        }

        float VerticalSpeedDelta
        {
            get;
        }
    }
}