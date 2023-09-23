using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerStepsController : PlayerControllerBase
    {
        [Header("====References====")]
        [SerializeField] Transform _walkParticleSpawn;
        [SerializeField] ParticleSystem _walkParticle;


        public void OnStep()
        {
            Instantiate(_walkParticle, _walkParticleSpawn.position, Quaternion.identity);
            AudioController.Instance.PlaySound("PlayerStep");
        }
    }
}