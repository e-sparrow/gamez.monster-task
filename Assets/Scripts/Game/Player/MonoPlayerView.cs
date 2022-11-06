using System;
using Game.Player.Interfaces;
using UnityEngine;

namespace Game.Player
{
    public class MonoPlayerView : MonoBehaviour, IPlayerView
    {
        public event Action OnCollide = () => { };
        public event Action OnPass = () => { };

        private void OnCollisionEnter2D()
        {
            OnCollide.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            OnPass.Invoke();
        }
    }
}