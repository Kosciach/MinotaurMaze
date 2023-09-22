using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public class PlayerAbilitiesController : PlayerControllerBase
    {
        [Header("====Settings====")]
        [SerializedDictionary("Enum", "Ability")]
        [SerializeField] SerializedDictionary<AbilitiesEnum, PlayerAbility> _abilities; public SerializedDictionary<AbilitiesEnum, PlayerAbility> Abilities { get { return _abilities; } }



        public void UseAbility(AbilitiesEnum ability)
        {
            _abilities[ability].Use();
        }
    }


    public enum AbilitiesEnum
    {
        PullToTheLight, Paralysis, Ghost, PortalTracker
    }
}