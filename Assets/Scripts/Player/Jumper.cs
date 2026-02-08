using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(LayerMask))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundCheckDistance = 2f;

    public void Jump(bool jumpPressed)
    {
        if (jumpPressed && IsGrounded())
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
      return Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _layerMask);
    }
}