using Assets.Scripts.Entities;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Effects
{
    [Serializable]
    public class AttackEffect : IEffect
    {
        [SerializeField][Min(0)] private float m_damage;

        public void Apply(IEffectable effectable)
        {
            if (effectable is IHealth health)
            {
                health.TakeDamage(m_damage);
            }
        }
    }
}