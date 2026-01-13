using Assets.Scripts.Magic.Effects;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpellAoe : MonoBehaviour, ISpellAoe
{
    public void Initialize(Vector3 targetPosition, float radius, IReadOnlyCollection<IEffect> effects)
    {
        var colliders = Physics.OverlapSphere(targetPosition, radius, gameObject.layer);

        foreach(var collider in colliders)
        {
            var effectables = collider.GetComponents<IEffectable>();
            effects.ApplyEffects(effectables);
        }
    }
}
