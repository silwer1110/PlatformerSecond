using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Folower : IMover
    {
        private Transform _target;
        private Transform _transform;
        private float _speed = 2f;
        private float _distanceToTarget = 0.5f;

        public Folower(Transform target, Transform transform, float speed, float distanceToTarget)
        {
            _target = target;
            _transform = transform;
            _speed = speed;
            _distanceToTarget = distanceToTarget;
        }

        public void Move()
        {
            if ((_transform.position - _target.position).sqrMagnitude > _distanceToTarget)
                _transform.position = Vector3.MoveTowards(_transform.position, _target.position, _speed * Time.deltaTime);
        }
    }
}