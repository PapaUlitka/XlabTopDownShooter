using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs
{
    public interface IBuff
    {
        public string Id { get; }

        public void Initialize(BuffContainer container);
        public void DeInitialize();

        public void Update(float deltaTime);

        public IBuff Clone();
    }
}