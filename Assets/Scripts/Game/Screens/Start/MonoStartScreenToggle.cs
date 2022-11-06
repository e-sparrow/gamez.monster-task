using Game.Level.Interfaces;
using Game.Screens.Start.Interfaces;
using TMPro;
using UnityEngine.UI;

namespace Game.Screens.Start
{
    public class MonoStartScreenToggle : Toggle, IStartScreenToggle
    {
        private TMP_Text _text;
        
        public void Initialize(ILevelDifficultyInfo difficulty)
        {
            _text ??= GetComponentInChildren<TMP_Text>();
            _text.text = difficulty.Name;
        }
    }
}