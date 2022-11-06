using System;
using System.Collections.Generic;
using System.Linq;
using Game.Level.Interfaces;
using Game.Screens.Start.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utils.Screens;

namespace Game.Screens.Start
{
    public class MonoStartScreen : MonoScreenBase<IStartScreenArgument>, IStartScreen
    {
        public event Action<ILevelDifficultyInfo> OnStartClicked = _ => { };

        [SerializeField] private Button startButton;
        
        [SerializeField] private Transform root;
        
        [SerializeField] private ToggleGroup group;
        [SerializeField] private MonoStartScreenToggle prefab;

        private readonly IDictionary<Toggle, ILevelDifficultyInfo> _toggles = new Dictionary<Toggle, ILevelDifficultyInfo>();

        public override void Show(IStartScreenArgument argument)
        {
            base.Show(argument);
            
            foreach (var difficulty in argument.Difficulties)
            {
                var toggle = Instantiate(prefab, root);
                toggle.group = group;
                
                toggle.Initialize(difficulty);

                _toggles.Add(toggle, difficulty);
            }
            
            
            _toggles.Keys.First().Select();

            startButton.onClick.AddListener(Click);
        }

        public override void Hide()
        {
            base.Hide();
            
            foreach (var toggle in _toggles)
            {
                Destroy(toggle.Key.gameObject);
            }
            
            _toggles.Clear();
            
            startButton.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            var current = group.GetFirstActiveToggle();
            if (current != null)
            {
                var difficulty = _toggles[current];
                OnStartClicked.Invoke(difficulty);
            }
        }
    }
}