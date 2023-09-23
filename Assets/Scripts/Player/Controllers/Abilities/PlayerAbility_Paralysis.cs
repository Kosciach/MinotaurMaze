using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public class PlayerAbility_Paralysis : PlayerAbility
    {
        protected override void UseAbility()
        {
            _currentCooldown = _cooldown;

            AudioController.Instance.PlaySound("Paralysis");
            _playerStateMachine.MinotaurStateMachine.SetStateSwitch(MinotaurStateMachineSystem.StateSwitches.Stun);
            _playerStateMachine.MinotaurStateMachine.Collider.enabled = false;
            StartCoroutine(ResetMinotaurStun());
        }


        private IEnumerator ResetMinotaurStun()
        {
            yield return new WaitForSeconds(6);
            _playerStateMachine.MinotaurStateMachine.SetStateSwitch(MinotaurStateMachineSystem.StateSwitches.Chase);
            _playerStateMachine.MinotaurStateMachine.Collider.enabled = true;
        }
    }
}