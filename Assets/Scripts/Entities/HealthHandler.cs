using System;
using UnityEngine;

namespace Entities
{
    public class HealthHandler : MonoBehaviour
    {
        public event EventHandler OnDeath;
        public event EventHandler HealthUpdated;

        [SerializeField]
        private int maxHealth;

        private int currentHealth;
        
        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                if (value < 0) value = 0;
                var delta = value - maxHealth;
                maxHealth = value;
                if (delta > 0) currentHealth += delta;
                currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
                if (currentHealth == 0)
                    OnDeath?.Invoke(this, EventArgs.Empty);
            }
        }

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, 0, maxHealth);
                HealthUpdated?.Invoke(this, EventArgs.Empty);
                if(currentHealth == 0)
                    OnDeath?.Invoke(this, EventArgs.Empty);
            }
        }

        private void Start()
        {
            CurrentHealth = maxHealth;
        }
    }
}