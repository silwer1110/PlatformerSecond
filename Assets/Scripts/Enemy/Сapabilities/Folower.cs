using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Folower 
    {
        private Transform _transform;
        private float _speed;
        private float _distanceToTarget;

        public Folower(Transform transform, float speed, float distanceToTarget)
        {
            _transform = transform;
            _speed = speed;
            _distanceToTarget = distanceToTarget;
        }

        public void Folow(Transform target)
        {
            if ((_transform.position - target.position).sqrMagnitude > _distanceToTarget)
                _transform.position = Vector3.MoveTowards(_transform.position, target.position, _speed * Time.deltaTime);
        }
    }
}