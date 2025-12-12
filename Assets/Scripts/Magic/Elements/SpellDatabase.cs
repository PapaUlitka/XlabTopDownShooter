using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Elements
{
    [CreateAssetMenu(fileName = "SpellDatabase", menuName = "Xlab/Magic/Spells/SpellDatabase")]
    public class SpellDatabase : ScriptableObject
    {
        [SerializeField] private BaseSpellData[] m_spells;

        public IReadOnlyList<BaseSpellData> Spells => m_spells;
    }
}