using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Elements
{
    [CreateAssetMenu(fileName = "AoeSpellData", menuName = "Xlab/Magic/Spells/Aoe Spell")]
    public class AoeSpellData : BaseSpellData
    {
        [SerializeField][Min(0f)] private float m_radius;

        public float radius => m_radius;
    }
}