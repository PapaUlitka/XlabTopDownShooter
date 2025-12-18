using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Spells.Data
{
    [CreateAssetMenu(fileName = "SpellDatabase", menuName = "Xlab/Magic/Spells/Spell Database")]
    public sealed class SpellDatabase : ScriptableObject
    {
        [SerializeField] private BaseSpellData[] m_spells;

        public IReadOnlyList<BaseSpellData> Spells => m_spells;
    }
}