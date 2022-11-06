using System;
using Game.Level.Interfaces;
using Utils.Signals;
using Utils.Signals.Interfaces;

namespace Game
{
    public static class GameSignals
    {
        public static ISignal OpenStartScreen = new Signal();
        
        public static ISignal<ILevelDifficultyInfo> GameStart = new Signal<ILevelDifficultyInfo>();
        public static ISignal<TimeSpan> GameOver = new Signal<TimeSpan>();
    }
}