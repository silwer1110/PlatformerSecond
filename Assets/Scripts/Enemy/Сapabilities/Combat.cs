using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Combat : MonoBehaviour
    {
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _atackRadius = 1f;  

        public void Atack(Character target)
        { 
            target.TakeDamage(_damage);
        }

        public Character GetTargetOnAtackRadius()
        {
            Character target = null;

            Collider2D hit = Physics2D.OverlapCircle(transform.position, _atackRadius, LayerMask.GetMask("Player"));

            if (hit != null && hit.TryGetComponent(out Character character))
                target = character;

            return target;
        }
    }
}