using Assets.Scripts.Entities;
using Assets.Scripts.Magic.Buffs.Base;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs.Impls
{
    [Serializable]
    public sealed class PoisonDebuff : TimedBuff
    {

        [SerializeField] [Min(0)] private float m_interval = 1;
        [SerializeField] [Min(0)] private float m_damagedPerSeconds = 2f;

        [NonSerialized] private float m_timer;
        private IHealth m_health;

        public PoisonDebuff() { }

        public PoisonDebuff(
            string id, 
            float duration,
            float interval,
            float damagePerSeconds) : base(id, duration)
        {
            m_interval = interval;
            m_damagedPerSeconds = damagePerSeconds;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            m_health = container.GetComponent<IHealth>();
        }
        protected override void OnDeInitializing()
        {
            m_timer = 0;
            m_health = null;
            base.OnDeInitializing();
        }
        protected override void OnUpdated(float deltaTime)
        {
            if(m_health is null)
            {
                DeInitialize();
                return;
            }
            if(m_timer < m_interval)
            {
                m_timer += deltaTime;
            }
            else
            {
                m_timer = 0;
                m_health.TakeDamage(m_damagedPerSeconds);
            }
        }

        public override IBuff Clone() => new PoisonDebuff(Id, duration, m_interval, m_damagedPerSeconds);
    }
}