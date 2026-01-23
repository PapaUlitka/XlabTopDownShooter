using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs
{
    public interface IBuff
    {
        public string Id { get; }
        public float Duration { get; }
        public float Timer { get; }

        public BuffType Type { get; }
        public Sprite Icon { get; }
        public void Initialize(BuffContainer container);
        public void DeInitialize();

        public void Update(float deltaTime);

        public IBuff Clone();
    }

    public interface ITimedBuff : IBuff
    {
        public float Duration { get; }
        public float Timer { get; }
    }
}