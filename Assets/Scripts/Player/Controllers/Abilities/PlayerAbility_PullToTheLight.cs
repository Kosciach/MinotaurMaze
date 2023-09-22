using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public class PlayerAbility_PullToTheLight : PlayerAbility
    {
        protected override void UseAbility()
        {
            _currentCooldown = _cooldown;

            LeanTween.value(_playerStateMachine.Controllers.Flashlight.FOV, 360, 0.5f).setOnUpdate((float val) =>
            {
                _playerStateMachine.Controllers.Flashlight.FOV = (int)val;
            });
            StartCoroutine(ResetFlashlight());
        }

        private IEnumerator ResetFlashlight()
        {
            yield return new WaitForSeconds(6);

            LeanTween.value(_playerStateMachine.Controllers.Flashlight.FOV, 90, 0.5f).setOnUpdate((float val) =>
            {
                _playerStateMachine.Controllers.Flashlight.FOV = (int)val;
            });
        }
    }
}