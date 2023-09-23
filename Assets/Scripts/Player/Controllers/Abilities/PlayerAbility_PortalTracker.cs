using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public class PlayerAbility_PortalTracker : PlayerAbility
    {
        [Header("====References====")]
        [SerializeField] PortalTrackerController _portalTracker;


        protected override void UseAbility()
        {
            AudioController.Instance.PlaySound("PortalTrail");
            Instantiate(_portalTracker, _playerStateMachine.transform.position, Quaternion.identity);
            _currentCooldown = _cooldown;
        }
    }
}