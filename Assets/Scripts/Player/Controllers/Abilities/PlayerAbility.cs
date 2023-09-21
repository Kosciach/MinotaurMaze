using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public abstract class PlayerAbility : PlayerControllerBase
    {
        [Header("====Cooldown====")]
        [SerializeField] float _cooldown;
        [SerializeField] float _currentCooldown;


        private new void Awake()
        {
            base.Awake();
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
            _currentCooldown = _cooldown;
        }

        protected abstract void UseAbility();
    }
}