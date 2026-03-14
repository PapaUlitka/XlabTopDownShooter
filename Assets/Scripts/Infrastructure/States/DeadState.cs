using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;

namespace Assets.Scripts.Infrastructure.States
{
    public class DeadState : IState
    {
        private readonly StateMachine m_stateMachine;
        private readonly DeadMenuView m_deadMenuView;

        public DeadState(StateMachine stateMachine, DeadMenuView deadMenuView)
        {
            m_stateMachine = stateMachine;
            m_deadMenuView = deadMenuView;

            deadMenuView.gameObject.SetActive(false);
        }

        public void Enter()
        {
            m_deadMenuView.GoToMenuClicked += OnGoToMenuClicked;
            m_deadMenuView.gameObject.SetActive(true);
        }

        public void Exit()
        {
            m_deadMenuView.GoToMenuClicked -= OnGoToMenuClicked;
            m_deadMenuView.gameObject.SetActive(false);
        }

        private void OnGoToMenuClicked()
        {
            m_stateMachine.ChangedState<GameplayExitState>();
        }
    }
}
