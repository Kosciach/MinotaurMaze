using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public abstract class PlayerAbility : PlayerControllerBase
    {
        [Header("====Cooldown====")]
        [SerializeField] protected float _cooldown;
        [SerializeField] protected float _currentCooldown;

        protected PlayerAbilitiesController _abilityController;


        private new void Awake()
        {
            base.Awake();
            _abilityController = _playerStateMachine.Controllers.Abilities;
            _currentCooldown = _cooldown;
        }
        private void Update()
        {
            CoolDownTimer();
        }


        private void CoolDownTimer()
        {
            _currentCooldown -= 1 * Time.deltaTime;
            _currentCooldown = Mathf.Clamp(_currentCooldown, 0, _cooldown);
        }

        public void Use()
        {
            if (_currentCooldown > 0) return;

            UseAbility();
        }

        protected abstract void UseAbility();
    }
}