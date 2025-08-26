using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    public float MovmentInput => Input.GetAxisRaw(Horizontal);
    public bool JumpPressed => Input.GetButtonDown(Jump);
}