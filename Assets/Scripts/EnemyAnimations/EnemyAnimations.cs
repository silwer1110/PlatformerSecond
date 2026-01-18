using UnityEngine;

public class EnemyAnimations : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void AnimateAttack(float distanceToTarget)
    {
        _animator.SetFloat(AnimatorData.Params.DistanceToTarget, distanceToTarget);
    }
}