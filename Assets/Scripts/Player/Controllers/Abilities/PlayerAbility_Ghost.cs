using PlayerStateMachineSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers.AbilitiesSystem
{
    public class PlayerAbility_Ghost : PlayerAbility
    {
        [Header("====References====")]
        [SerializeField] Collider2D _playerCollider;
        [SerializeField] SpriteRenderer _playerSprite;


        private bool _isInUse; public bool IsInUse { get { return _isInUse; } }

        protected override void UseAbility()
        {
            _isInUse = true;
            _currentCooldown = _cooldown;

            _playerCollider.enabled = false;
            LeanTween.color(_playerSprite.gameObject, new Color(1, 1, 1, 0.2f), 0.2f);
            StartCoroutine(ResetCollider());
        }


        private IEnumerator ResetCollider()
        {
            yield return new WaitForSeconds(1);

            _playerCollider.enabled = true;
            LeanTween.color(_playerSprite.gameObject, new Color(1, 1, 1, 1), 0.2f);

            _isInUse = false;
        }
    }
}