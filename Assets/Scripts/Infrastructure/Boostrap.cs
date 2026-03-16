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

        [SerializeField] private AudioService m_audioService;

        private void Awake()
        {
            ServiceLocator.Clear();

            m_audioService.Initialize();
            ServiceLocator.Register(m_loading);
            ServiceLocator.Register(m_audioService);
        }

        private void Start()
        {
            m_audioService.Initialize();
        }
    }
}
