using Assets.Scripts.Enemy.Capabilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterCombat : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private CharacterDetector _detector;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _attackDelay = 1f;

        private Coroutine _attackCoroutine;

        private bool _isAttacking = false;

        private void OnEnable()
        {
            _detector.Detected += StartAttacking;
            _detector.Lost += StopAttacking;
        }

        private void OnDisable()
        {
            _detector.Detected -= StartAttacking;
            _detector.Lost -= StopAttacking;
        }

        private void StartAttacking(FlyingEye target)
        {
            if (_isAttacking)
                return;

            _attackCoroutine = StartCoroutine(AttackLoop(target));
        }

        private void StopAttacking()
        {
            if (_attackCoroutine != null)
                StopCoroutine(_attackCoroutine);

            _animator.StopAttacking();
            _isAttacking = false;
        }

        private IEnumerator AttackLoop(FlyingEye target)
        {
            WaitForSeconds wait = new(_attackDelay);

            while (enabled)
            {
                _isAttacking = true;

                _animator.AnimateAttack();
                target.HealthView.TakeDamage(_damage);

                yield return wait;
            }

            _animator.StopAttacking();
            _isAttacking = false;
        }
    }
}
