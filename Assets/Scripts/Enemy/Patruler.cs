using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Patruler : IMover
    {
        private Transform _transform;
        private WayHendel _wayHendel;
        private Vector3 _target;
        private float _speed = 5f;
        private float _distanceBetweenPoints = 0.2f;

        public Patruler(WayHendel wayHendel, float speed, float distanceBetweenPoints, Transform transform)
        {
            _wayHendel = wayHendel;
            _speed = speed;
            _distanceBetweenPoints = distanceBetweenPoints;
            _transform = transform;
            _target = _wayHendel.GetNextPosition();
        }

        public void Move()
        {
            if ((_transform.position - _target).sqrMagnitude > _distanceBetweenPoints)
                _transform.position = Vector2.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
            else
                _target = _wayHendel.GetNextPosition();
        }
    }
}