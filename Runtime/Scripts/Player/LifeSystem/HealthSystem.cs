using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace YodeGroup.Runner
{
    public class HealthSystem : GameService
    {
        [SerializeField, Min(1)] private int maxHealth = 3;
        [SerializeField] private UnityEvent<int> onHealthChanged;
        [SerializeField] private UnityEvent onDie;

        private int _health;

        public int Health
        {
            get => _health;
            private set
            {
                _health = Mathf.Clamp(value, 0, int.MaxValue);
                onHealthChanged?.Invoke(_health);
                if (_health == 0)
                    onDie?.Invoke();
            }
        }

        protected override void OnStartService()
        {
            SetMaxHealth();
        }

        protected override void OnStopService()
        {
        }

        protected override void OnPause()
        {
        }

        protected override void OnResume()
        {
        }

        public void ReduceHealth()
        {
            Health -= 1;
        }

        public void RaiseHealth()
        {
            Health += 1;
        }

        public void SetMaxHealth()
        {
            Health = maxHealth;
        }

        public void RemoveAllHealth()
        {
            Health = 0;
        }
    }
}