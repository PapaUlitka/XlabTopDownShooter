using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Effects
{
    public interface IEffect
    {
        public void Apply(IEffectable effectable);
    }
    public interface IEffectable { }
}