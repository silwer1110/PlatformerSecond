using UnityEngine;

namespace Assets.Scripts.Enemy.Capabilities
{
    public class EnemyDetector
    {
        private Transform _transform;
        private float _baseRadius;

        public EnemyDetector(Transform transform, float radius)
        {
            _transform = transform;
            _baseRadius = radius;
        }

        public bool DetectPlayer()
        {
            Collider2D hit;

            hit = Physics2D.OverlapCircle(_transform.position, _baseRadius, LayerMask.GetMask("Player"));

            return hit != null;
        }

        public Character GetPlayerOnRadius(float radius)
        {
            Character target = null;

            Collider2D hit = Physics2D.OverlapCircle(_transform.position, radius, LayerMask.GetMask("Player"));

            if (hit == null)
                return target;

            if (hit.TryGetComponent<Character>(out Character character))
                target = character;

            return target;
        }
    }
}