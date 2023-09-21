using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerRotationController : PlayerControllerBase
    {
        [Header("====Debugs====")]
        [SerializeField] Vector3 _target;


        [Space(20)]
        [Header("====Settings====")]
        [Range(0, 10)]
        [SerializeField] float _lookAtTargetSpeed;



        public void RotateToMouse()
        {
            _target = Vector3.Lerp(_target, _playerStateMachine.Controllers.Input.MouseWorldPosition, _lookAtTargetSpeed * 2 * Time.deltaTime);

            float diffX = _target.x - transform.position.x;
            float diffY = _target.y - transform.position.y;

            float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}