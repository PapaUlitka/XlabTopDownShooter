using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs
{
    public interface IBuff
    {
        public string Id { get; }

        public Sprite Icon { get; }

        public BuffType Type { get; }

        public void Initialize(BuffContainer container);

        public void Deinitialize();

        public void Update(float deltaTime);

        public IBuff Clone();
    }

    public interface ITimedBuff : IBuff
    {
        public float timer { get; }

        public float duration { get; }
    }
}
