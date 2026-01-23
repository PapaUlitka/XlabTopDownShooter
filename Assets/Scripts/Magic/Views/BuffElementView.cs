using Assets.Scripts.Magic.Buffs;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Magic.Views
{
    public class BuffElementView : MonoBehaviour
    {
        [SerializeField] private Image m_iconImage;
        [SerializeField] private Image m_timerImage;

        private IBuff m_buff;
        public void Initialize(IBuff buff)
        {
            m_buff = buff;
            m_timerImage.fillAmount = 1;
            gameObject.SetActive(true);
            m_iconImage.sprite = buff.Icon;
        }
        public void Deinitialize()
        {
            m_buff = null;
            m_timerImage.fillAmount = 0;
            gameObject.SetActive(false);
        }
        private void Update()
        {
            if (m_buff is ITimedBuff timedBuff)
            {
                m_timerImage.fillAmount = timedBuff.Timer / timedBuff.Duration;
            }
        }
    }
}