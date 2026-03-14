using Assets.Scripts.Entities;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Effects
{
    [Serializable]
    public sealed class HealEffect : IEffect
    {
        [SerializeField][Min(0)] private float m_heal;

        public void Apply(IEffectable effectable)
        {
            if (effectable is IHealth health)
            {
                health.Heal(m_heal);
            }
        }
    }
}