using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
 
    public void AnimateRun(float direction, float speed)
    {
        _animator.SetFloat(AnimatorData.Params.Speed, Mathf.Abs(direction * speed));
    }
}