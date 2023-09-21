using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControllers.AbilitiesSystem;

namespace PlayerControllers
{
    public class PlayerInputController : PlayerControllerBase
    {
        [Header("====Debugs====")]
        [SerializeField] Camera _camera;


        [Space(20)]
        [Header("====Debugs====")]
        [SerializeField] Vector3 _movementInputVector; public Vector3 MovementInputVector { get { return _movementInputVector; } }
        [SerializeField] Vector3 _mouseWorldPosition; public Vector3 MouseWorldPosition { get { return _mouseWorldPosition; } }


        private PlayerInputs _inputs;



        protected new void Awake()
        {
            base.Awake();

            _inputs = new PlayerInputs();
        }
        private void Update()
        {
            SetMovementInputVector();
            SetMouseWorldPosition();
        }
        private void Start()
        {
            GetAbilityInput();
        }



        private void SetMovementInputVector()
        {
            Vector2 movementInputVector = _inputs.Player.Move.ReadValue<Vector2>();
            _movementInputVector = new Vector3(movementInputVector.x, 0, movementInputVector.y);
        }
        private void SetMouseWorldPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -_camera.transform.position.z;
            _mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
        }
        private void GetAbilityInput()
        {
            _inputs.Player.MinotaurInsight.performed += ctx => _playerStateMachine.Controllers.Abilities.UseAbility(AbilitiesEnum.MinotaurInsight);
            _inputs.Player.Paralysis.performed += ctx => _playerStateMachine.Controllers.Abilities.UseAbility(AbilitiesEnum.Paralysis);
            _inputs.Player.Ghost.performed += ctx => _playerStateMachine.Controllers.Abilities.UseAbility(AbilitiesEnum.Ghost);
            _inputs.Player.PortalTracker.performed += ctx => _playerStateMachine.Controllers.Abilities.UseAbility(AbilitiesEnum.PortalTracker);
            _inputs.Player.Camoflauge.performed += ctx => _playerStateMachine.Controllers.Abilities.UseAbility(AbilitiesEnum.Camoflauge);
        }



        private void OnEnable() => _inputs.Enable();
        private void OnDisable() => _inputs.Disable();
    }
}