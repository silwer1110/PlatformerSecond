using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.Capabilities
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _attackRadius = 1f;
        [SerializeField] private float _attackCooldown = 1f;

        private Coroutine _attackCoroutine;
        private Character _target;
        private EnemyDetector _detector;
        private WaitForSeconds _cooldownWait;

        private bool _isAttacking = false;

        public float AttackRadius => _attackRadius;
        public bool IsAttacking => _isAttacking;

        private void Awake()
        {
            _detector = new(transform, _attackRadius);
            _cooldownWait = new(_attackCooldown);
        }

        public void StopAttack()
        {
            _isAttacking = false;
            _animations.StopAnimateAttack();

            if (_attackCoroutine != null)
                StopCoroutine(_attackCoroutine);
        }

        public void StartAttacking()
        {
            _isAttacking = true;

            _attackCoroutine = StartCoroutine(AttackLoop());
        }

        public void DealDamage()
        {
            _target = _detector.GetPlayerOnRadius(_attackRadius);

            if (_target == null)
                return;

            _target.HealthView.TakeDamage(_damage);
        }

        private IEnumerator AttackLoop()
        {
            _target = _detector.GetPlayerOnRadius(_attackRadius);

            while (_target != null)
            {
                _animations.LookAtTarget(_target.transform.position);
                _animations.AnimateAttack();
                yield return _cooldownWait;
            }

            StopAttack();
        }
    }
}