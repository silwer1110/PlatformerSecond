using System.Collections;
using UnityEngine;

public class AttackHendel : MonoBehaviour
{
    [SerializeField] private EnemyAnimations _enemyAnimations;
    [SerializeField] private float _attackDamge = 1f;
    [SerializeField] private float _attackRadius = 2f;
    [SerializeField] private float _attackCuldown = 2f;

    public void StartAttack(Character character)
    {
        StartCoroutine(CanAttackTargetRoutine(character)); 
    }

    private IEnumerator CanAttackTargetRoutine(Character target)
    {
        WaitForSeconds wait = new(_attackCuldown);

        while (enabled)
        {
            while ((transform.position - target.GetCurrentPosition().position).sqrMagnitude > _attackRadius)
            {
                Attack(target);

                yield return wait;
            }
        }
    }

    private void Attack(Character character)
    {
        _enemyAnimations.AnimateAttack((transform.position - character.GetCurrentPosition().position).sqrMagnitude);

        character.TakeDamage(_attackDamge);
    }

    //private void Flip(Transform target)
    //{
    //    Vector3 direction = target.position - transform.position;
    //    direction.y = 0f;

    //    if (direction != Vector3.zero)
    //        transform.rotation = Quaternion.LookRotation(direction);
    //}
}