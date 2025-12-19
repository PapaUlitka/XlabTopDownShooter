using Assets.Scripts.Magic.Elements;
using Assets.Scripts.Magic.Spells.Data;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Data
{
    [CreateAssetMenu(fileName = "MagicConfig", menuName = "Xlab/Magic/MagicConfig")]
    public sealed class MagicConfig : ScriptableObject
    {
        [SerializeField] private ElementsData m_elementsData;
        [SerializeField] private SpellDatabase m_spellDatabase;

        [SerializeField][Min(1)] private int m_maxElements = 3;
        [SerializeField][Min(0)] private float m_cancelCooldown = 0.3f;

        public ElementsData ElementsData => m_elementsData;

        public SpellDatabase SpellDatabase => m_spellDatabase;

        public int maxElements => m_maxElements;

        public float cancelCooldown => m_cancelCooldown;
    }
}