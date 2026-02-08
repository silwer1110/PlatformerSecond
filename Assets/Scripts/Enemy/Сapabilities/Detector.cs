using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
    public class Detector 
    {
        private Transform _transform;
        private float _radius;

        public Detector(Transform transform, float radius)
        {
            _transform = transform;
            _radius = radius;
        }

        public bool DetectPlayer()
        {
            Collider2D hit;

            hit = Physics2D.OverlapCircle(_transform.position, _radius, LayerMask.GetMask("Player"));

            return hit != null;
        }

        public Transform GetPlayerPosition()
        {
            Character target = null;

            Collider2D hit = Physics2D.OverlapCircle(_transform.position, _radius, LayerMask.GetMask("Player"));

            if (hit.TryGetComponent<Character>(out Character character))
                target = character;

            return target.transform;
        }
    }
}