using UnityEngine;

public class EnemyAnimations : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    private Vector3 _scale;

    private  float _directionThreshold = 0.01f;
    private float _direction;

    private bool _isFacingRight;

    public void AnimateAttack()
    {
        _animator.SetTrigger(AnimatorData.Params.PlayerOnRadius);
    }

    public void StopAnimateAttack()
    {
        _animator.SetTrigger(AnimatorData.Params.PlayerOutOfRadius);
    }

    public void LookAtTarget(Vector3 target)
    {
        _direction = target.x - transform.position.x;

        if (_direction < _directionThreshold && !_isFacingRight)
            Flip();
        else if (_direction > -_directionThreshold && _isFacingRight)
            Flip();
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _scale = transform.localScale;
        _scale.x *= -1;
        transform.localScale = _scale;
    }
}