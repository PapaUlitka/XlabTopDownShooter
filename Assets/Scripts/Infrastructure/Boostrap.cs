using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    [DefaultExecutionOrder(-500)]
    public class Boostrap : MonoBehaviour
    {
        [SerializeField] private Loading m_loading;

        private void Awake()
        {
            ServiceLocator.Clear();
            ServiceLocator.Register(m_loading);
        }
    }
}
