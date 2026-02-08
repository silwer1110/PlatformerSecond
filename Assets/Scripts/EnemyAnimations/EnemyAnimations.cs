using UnityEngine;

public class EnemyAnimations : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    public void Attack(bool canAtack)
    {       
        _animator.SetBool(AnimatorData.Params.isAtacking, canAtack);
    }
}