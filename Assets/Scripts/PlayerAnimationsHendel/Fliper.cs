using UnityEngine;

public class Fliper : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private Vector2 _left = new(0f, 180f);
    private Vector2 _right = new(0f, 0f);

    public void Flip(float moveDirection)
    {
        if (moveDirection > 0)
            _transform.rotation = Quaternion.Euler(_right);
        else if (moveDirection < 0)
            _transform.rotation = Quaternion.Euler(_left);
    }
}