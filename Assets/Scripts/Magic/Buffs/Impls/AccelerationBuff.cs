using Assets.Scripts.Entities;
using Assets.Scripts.Magic.Buffs.Base;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs.Impls
{
    [Serializable]
    public class AccelerationBuff : TimedBuff
    {
        [SerializeField] private float m_value;

        private IAcceleration m_acceleration;

        public AccelerationBuff(
            string id,
            float duration,
            float value) : base(id, duration)
        {
            m_value = value;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            m_acceleration = container.GetComponent<IAcceleration>();

            if(m_acceleration is null)
            {
                DeInitialize();
            }
            else
            {
                m_acceleration.IncreaseAcceleration(m_value);
            }

        }

        protected override void OnDeInitializing()
        {
            m_acceleration?.DecreaseAcceleration(m_value);
            base.OnInitialized();
        }

        public override IBuff Clone() => new AccelerationBuff(Id, duration, m_value);
    }
}