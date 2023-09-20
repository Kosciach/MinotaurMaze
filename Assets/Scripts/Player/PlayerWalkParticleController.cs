using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerWalkParticleController : PlayerControllerBase
    {
        [Header("====References====")]
        [SerializeField] ParticleSystem _walkParticle;



        private void Awake()
        {
            OnAwake();
        }


        public void CheckIfShouldPlay()
        {
            if(_playerStateMachine.Controllers.Movement.CurrentMovement.magnitude != 0)
            {
                if(_walkParticle.isPaused) _walkParticle.Play();
                return;
            }

            if (_walkParticle.isPlaying) _walkParticle.Pause();
        }
    }
}