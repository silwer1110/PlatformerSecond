using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class AtackHendler : IAtackHendeler
    {
        private Transform _transform;
        private EnemyAnimations _animations;
        private Character _target;
        private float _damage;
        private float _atackDistance;

        public AtackHendler(float damage, float atackDistance, Character target, Transform transform, EnemyAnimations animations)
        {
            _animations = animations;
            _damage = damage;
            _atackDistance = atackDistance;
            _target = target;
            _transform = transform;
        }

        public void Atack()
        {
            if ((_transform.position - _target.transform.position).sqrMagnitude <= _atackDistance)
            {
                _animations.AnimateAttack((_transform.position - _target.transform.position).sqrMagnitude);

                _target.TakeDamage(_damage);
            }
        }
    }
}