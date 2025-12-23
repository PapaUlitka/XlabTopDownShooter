using Assets.Scripts.Magic.Effects;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class HealthComponent : MonoBehaviour, IHealth, IEffectable
    {
        public event Action Died;
        public event Action ValueChanged;

        private float m_value;
        private bool m_initialized;
        public float Value
        {
            get => m_value;
            private set
            {
                if (Mathf.Approximately(m_value, value))
                {
                    return;
                }

                m_value = value < 0 ? 0 : value;

                if (m_value is 0)
                {
                    Died?.Invoke();
                }
            }
        }

        public void Initialize(float value)
        {
            if (!m_initialized)
            {
                throw new InvalidOperationException("HealthComponent is already initialize");
            }

            m_value = value;
            m_initialized = true;
        }

        public void Heal(float heal)
        {
            if (heal < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(heal), heal, "Heal cannot be negative");
            }

            Value += heal;


        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage), damage, "Damage cannot be negative");
            }

            Value -= damage;
        }
    }
}