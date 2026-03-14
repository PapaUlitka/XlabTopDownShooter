using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Magic.Spells.Data
{
    [CreateAssetMenu(fileName = "SpellsDataBase", menuName = "XLab/Magic/Spells/Spells Database")]
    public sealed class SpellsDatabase : ScriptableObject
    {
        [SerializeField] private BaseSpellData[] m_spells;

        public IReadOnlyList<BaseSpellData> Spells => m_spells;
    }
}
