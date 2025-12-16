using Assets.Scripts.Magic.Data;
using Assets.Scripts.Magic.Elements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Magic.Systems
{
    public class MagicSystem : MonoBehaviour
    {
        public event Action SpellCancelled;
        public event Action<MagicState> StateChanged;
        public event Action<IReadOnlyList<ElementType>> ElementChanged
        {
            add => spellPreparation.ElementChanged += value;
            remove => spellPreparation.ElementChanged -= value;
        }

        [SerializeField] private MagicConfig m_config;

        private MagicState m_state;
        private SpellCaster m_caster;
        private SpellPreparation m_spellPreparation;
        private Coroutine m_cooldownCoroutine;

        public MagicState state
        {
            get => m_state;
            private set
            {
                if(m_state != value)
                {
                    m_state = value;
                    StateChanged?.Invoke(m_state);
                }
            }
        }
        private void Awake()
        {
            m_caster = new SpellCaster(transform);
        }
        private SpellPreparation spellPreparation => m_spellPreparation ??= new SpellPreparation(m_config);

        private void OnEnable()
        {
            spellPreparation.OverflowOccurred += CancelSpell;
        }
        private void OnDisable()
        {
            spellPreparation.OverflowOccurred -= CancelSpell;
        }

        public void AddElement(ElementType element)
        {
            if (state is MagicState.Cooldown or MagicState.Casting)
            {
                return;
            }
            spellPreparation.AddElement(element);
            state = MagicState.Preparation;
        }

        private void CancelSpell()
        {
            if(state is MagicState.Preparation)
            {
                spellPreparation.Clear();
                SpellCancelled?.Invoke();

                StartCooldown();
            }
        }

        private void StartCooldown()
        {
            if(m_cooldownCoroutine is not null)
            {
                StopCoroutine(m_cooldownCoroutine);
            }
            m_cooldownCoroutine = StartCoroutine(CooldownRoutine());
        }

        private IEnumerator CooldownRoutine()
        {
            state = MagicState.Cooldown;
            yield return new WaitForSeconds(m_config.cancelCooldown);
            state = MagicState.Idle;

            m_cooldownCoroutine = null;
        }

        public void TryCastSpell()
        {
            if(state is not MagicState.Preparation)
            {
                return;
            }
            if (spellPreparation.TryGetSpell(out var spell))
            {
                state = MagicState.Casting;

                m_caster.Cast(spell, Vector3.zero);

                spellPreparation.Clear();
                state = MagicState.Idle;
            }
            else
            {
                CancelSpell();
            }
        }
    }
    public enum MagicState
    {
        Idle,
        Preparation,
        Cooldown,
        Casting
    }
}