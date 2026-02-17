using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
 
    public void AnimateRun(float direction, float speed)
    {
        _animator.SetFloat(AnimatorData.Params.Speed, Mathf.Abs(direction * speed));
    }

    public void AnimateAttack()
    {
        _animator.SetTrigger(AnimatorData.Params.EnemyOnRadius);
    }

    public void StopAttacking() 
    {
        _animator.SetTrigger(AnimatorData.Params.EnemyOutOfRadius);

    }
}