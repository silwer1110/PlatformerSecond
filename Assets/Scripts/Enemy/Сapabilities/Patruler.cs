using UnityEngine;

namespace Assets.Scripts.Enemy.Capabilities
{
    public class Patruler : MonoBehaviour
    {
        [SerializeField] private WayHendel _wayHendel;
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _distanceBetweenPoints = 0.01f;

        private Vector3 _target;

        private void Awake()
        {
            _target = _wayHendel.GetNextPosition();
        }

        public void Patrule()
        {
            _animations.LookAtTarget(_target);

            if ((transform.position - _target).sqrMagnitude > _distanceBetweenPoints)
                transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
            else
                _target = _wayHendel.GetNextPosition();
        }
    }
}