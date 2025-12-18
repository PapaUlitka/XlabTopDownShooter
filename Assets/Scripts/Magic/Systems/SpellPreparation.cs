using Assets.Scripts.Magic.Data;
using Assets.Scripts.Magic.Elements;
using Assets.Scripts.Magic.Spells.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Systems
{
    public class SpellPreparation
    {
        public event Action<IReadOnlyList<ElementType>> ElementChanged;
        public event Action OverflowOccurred;
        private MagicConfig m_magicConfig;
        private List<ElementType> m_elements = new();

        public SpellPreparation(MagicConfig magicConfig)
        {
            m_magicConfig = magicConfig;
        }
        public void AddElement(ElementType elementType)
        {
            if (m_elements.Count >= m_magicConfig.maxElements)
            {
                Clear();
                OverflowOccurred?.Invoke();
            }
            else
            {
                m_elements.Add(elementType);
                ElementChanged?.Invoke(m_elements);
            }
        }

        public bool TryGetSpell(out BaseSpellData spell)
        {
            spell = null;
            if (m_elements.Count is 0)
            {
                return false;
            }
            foreach(var spellData in m_magicConfig.SpellDatabase.Spells)
            {
                if (IsMatchCombination(spellData.combination))
                {
                    spell = spellData;
                    return true;
                }

            }
            return false;
        }
        private bool IsMatchCombination(IReadOnlyList<ElementType> combination)
        {
            if(combination.Count != m_elements.Count)
            {
                return false;
            }
            for(var i = 0; i < combination.Count; i++)
            {
                if (combination[i] != m_elements[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void Clear()
        {
            m_elements.Clear();
            ElementChanged?.Invoke(m_elements);
        }
    }
}