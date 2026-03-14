using Assets.Scripts.Magic.Effects;
using System.Collections.Generic;
using UnityEngine;

public static class EffectsExtensions
{
    public static void ApplyEffects(
        this IReadOnlyCollection<IEffect> effects,
        IEffectable effectable)
    {
        if (effects is null) return;

        foreach (var effect in effects)
        {
            effect?.Apply(effectable);
        }
    }

    public static void ApplyEffects(
        this IReadOnlyCollection<IEffect> effects,
        IReadOnlyCollection<IEffectable> effectables)
    {
        if (effects is null) return;

        foreach (var effect in effects)
        {
            foreach (var effectable in effectables)
            {
                effect?.Apply(effectable);
            }
        }
    }
}