using Assets.Scripts.Magic.Buffs;
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Effects
{
    [Serializable]
    public class BuffEffect : IEffect
    {
        [SerializeReferenceDropdown]
        [SerializeReference] private IBuff[] m_buffs;
        public void Apply(IEffectable effectable)
        {
            if (effectable is BuffContainer container)
            {
                foreach(var buff in m_buffs)
                {
                    container.Add(buff.Clone() as IBuff);
                }

            }
        }
    }
}