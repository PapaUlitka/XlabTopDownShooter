using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IHealth
    {
        public void Heal(float heal);

        public void TakeDamage(float damage);
    }
}