using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerControllers.AbilitiesSystem
{
    public abstract class PlayerAbility : PlayerControllerBase
    {
        [Header("====Cooldown====")]
        [SerializeField] protected float _cooldown;
        [SerializeField] protected float _currentCooldown;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _cooldownText;

        protected PlayerAbilitiesController _abilityController;


        private new void Awake()
        {
            base.Awake();
            _abilityController = _playerStateMachine.Controllers.Abilities;
            _currentCooldown = 0;
        }
        private void Update()
        {
            CoolDownTimer();
        }


        private void CoolDownTimer()
        {
            _currentCooldown -= 1 * Time.deltaTime;
            _currentCooldown = Mathf.Clamp(_currentCooldown, 0, _cooldown);


            _cooldownText.text = _currentCooldown.ToString("F1");
            _icon.color = new Color(0.1f, 0.1f, 0.1f, 1);
            if (_currentCooldown > 0) return;

            _cooldownText.text = "";
            _icon.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        public void Use()
        {
            if (_currentCooldown > 0) return;

            UseAbility();
        }

        protected abstract void UseAbility();
    }
}