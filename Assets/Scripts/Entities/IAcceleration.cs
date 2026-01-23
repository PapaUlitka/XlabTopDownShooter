using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public interface IAcceleration
    {
        public void IncreaseAcceleration(float delta);
        public void DecreaseAcceleration(float delta);
    }
}