using Assets.Scripts.Inputs;
using Assets.Scripts.Players;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootstrapState : MonoBehaviour, IState
    {
        [SerializeField] private MouseResolver m_mouseResolver;
        [SerializeField] private PlayerSpawnPoint m_playerSpawnPoint;

        private StateMachine m_stateMachine;

        public void Initialize(StateMachine stateMachine)
        {
            m_stateMachine = stateMachine;
        }

        public void Enter()
        {
            ServiceLocator.Register(m_mouseResolver);

            var playerFactory = new PlayerFactory("Prefabs/Player");

            ServiceLocator.Register<IPlayerFactory>(playerFactory);
            ServiceLocator.Register<IPlayerFactorySettings>(playerFactory);

            ServiceLocator.Register(m_playerSpawnPoint);
            m_stateMachine.ChangedState<GameplayEntryState>();
        }

        public void Exit() { }
    }
}
