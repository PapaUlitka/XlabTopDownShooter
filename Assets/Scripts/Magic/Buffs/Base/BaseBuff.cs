using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Buffs.Base
{
    [Serializable]
    public abstract class BaseBuff : IBuff
    {


        [field: SerializeField]
        public string Id { get; private set; }

        protected BuffContainer container { get; private set; }
        
        public BaseBuff() { }

        protected BaseBuff(string id)
        {
            Id = id;
        }

        public void DeInitialize()
        {
            OnDeInitializing();
            container.Remove(this);
            container = null;
        }

        public void Initialize(BuffContainer container)
        {
            this.container = container;
            OnInitialized();
        }

        protected virtual void OnInitialized() { }

        protected virtual void OnDeInitializing() { }

        public virtual void Update(float deltaTime) { }

        public abstract IBuff Clone();
    }
}