using Assets.Scripts.Entities;
using Assets.Scripts.Magic.Buffs.Base;
using System;
using System.Collections.Generic;
using System.Text;
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
            Sprite icon,
            BuffType type,
            float duration,
            float value)
            : base(id, icon, type, duration)
        {
            m_value = value;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            m_acceleration = container.GetComponent<IAcceleration>();

            if (m_acceleration is null)
            {
                Deinitialize();
            }
            else
            {
                m_acceleration.IncreaseAcceleration(m_value);
            }
        }

        protected override void OnDeinitializing()
        {
            m_acceleration?.DecreaseAcceleration(m_value);
            base.OnDeinitializing();
        }

        public override IBuff Clone() =>
            new AccelerationBuff(Id, Icon, Type, duration, m_value);
    }
}
