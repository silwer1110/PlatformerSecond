using Assets.Scripts.Player;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private HealthView _healthView;
    [SerializeField] private CharacterCombat _characterCombat;
    [SerializeField] private Collector collector;

    public HealthView HealthView => _healthView;    

    private void Update()
    {
        _jumper.Jump(_inputReader.JumpPressed);
        _mover.Move(_inputReader.MovmentInput);
    }
}