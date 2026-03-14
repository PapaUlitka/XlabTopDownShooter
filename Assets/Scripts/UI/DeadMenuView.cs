using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class DeadMenuView : MonoBehaviour
    {
        public event Action GoToMenuClicked;

        [SerializeField] private Button m_goToMainMenuButton;

        private void OnEnable()
        {
            m_goToMainMenuButton.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            m_goToMainMenuButton.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked() =>
            GoToMenuClicked?.Invoke();
    }
}
