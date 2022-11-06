using System;
using Game.Screens.GameOver.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils.Screens;

namespace Game.Screens.GameOver
{
    public class MonoGameOverScreen : MonoScreenBase<IGameOverScreenArgument>, IGameOverScreen
    {
        public event Action OnRequestChangeDifficulty = () => { };
        public event Action OnRequestTryAgain = () => { };
        
        [SerializeField] private TMP_Text attemptTimer;
        [SerializeField] private TMP_Text attemptCounter;

        [SerializeField] private Button changeDifficultyButton;
        [SerializeField] private Button tryAgainButton;
        
        public override void Show(IGameOverScreenArgument argument)
        {
            base.Show(argument);

            var timeValue = argument.AttemptTime.ToString("0.##");
            attemptTimer.text = $"Длительность попытки: <color=#0000FF>{timeValue}</color>c";

            var countValue = argument.AttemptsCount.ToString();
            var countText = $"Всего попыток: <color=#FF0000>{countValue}</color>";
            if (argument.AttemptsCount == 15)
            {
                countText += $"\nВам понравилось?";
            }

            attemptCounter.text = countText;
            
            changeDifficultyButton.onClick.AddListener(ChangeDifficulty);
            tryAgainButton.onClick.AddListener(TryAgain);
        }

        public override void Hide()
        {
            base.Hide();
            
            changeDifficultyButton.onClick.RemoveListener(ChangeDifficulty);
            tryAgainButton.onClick.RemoveListener(TryAgain);
        }

        private void ChangeDifficulty()
        {
            OnRequestChangeDifficulty.Invoke();
        }

        private void TryAgain()
        {
            OnRequestTryAgain.Invoke();
        }
    }
}