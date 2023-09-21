using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerMinotaurDetector : PlayerControllerBase
    {
        [Header("====References====")]
        [SerializeField] SpriteRenderer _arrow;
        [SerializeField] CinemachineVirtualCamera _cineCamera;


        [Space(20)]
        [Header("====Debugs====")]
        [SerializeField] float _distanceToMinotaur;


        private CinemachineBasicMultiChannelPerlin _cineNoise;



        private new void Awake()
        {
            base.Awake();
            _cineNoise = _cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }


        public void CheckForMinotaur()
        {
            SetDistanceToMinotaur();
            HandleArrow();
            HandleCameraShake();
        }

        private void SetDistanceToMinotaur()
        {
            _distanceToMinotaur = Vector2.Distance(_playerStateMachine.transform.position, _playerStateMachine.MinotaurStateMachine.transform.position);
        }
        private void HandleArrow()
        {
            //Rotation
            float diffX = _playerStateMachine.MinotaurStateMachine.transform.position.x - transform.position.x;
            float diffY = _playerStateMachine.MinotaurStateMachine.transform.position.y - transform.position.y;

            float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);


            //Alpha
            float alpha = _distanceToMinotaur/7;
            alpha = Mathf.Clamp(alpha, 0, 1);
            alpha = 1 - alpha;

            Color colorWithNewAlpha = _arrow.color;
            colorWithNewAlpha.a = alpha;
            _arrow.color = colorWithNewAlpha;
            _arrow.color = colorWithNewAlpha;
        }
        private void HandleCameraShake()
        {
            float amplitude = _distanceToMinotaur / 7;
            amplitude = Mathf.Clamp(amplitude, 0, 1);
            amplitude = 1 - amplitude;
            _cineNoise.m_AmplitudeGain = amplitude * 2;
        }
    }
}