using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _health = 5;

    private Transform _transform;

    public float Health => _health;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _jumper.Jump(_inputReader.JumpPressed);
        _mover.Move(_inputReader.MovmentInput);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Auch");

        if (_health > 0)
            _health-= damage;
    }

    public Transform GetCurrentPosition()
    {
        return _transform;
    }
}