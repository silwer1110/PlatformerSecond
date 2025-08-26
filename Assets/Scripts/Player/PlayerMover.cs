using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(PlayerAnimator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerAnimator _animationHandel;
    [SerializeField] private Fliper _fliper;

    public void Move(float moveDirection)
    {
        _rigidbody.velocity = new Vector2(moveDirection * _moveSpeed, _rigidbody.velocity.y);

        _fliper.Flip(moveDirection);

        _animationHandel.AnimateRun(moveDirection, _moveSpeed);
    }
}