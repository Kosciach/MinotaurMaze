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
            _currentCooldown = _cooldown;
            _portalTracker.transform.position = transform.position;
            _portalTracker.OnUse();
        }
    }
}