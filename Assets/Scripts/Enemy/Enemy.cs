using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private MovmentHendel _movmentHendel;
    [SerializeField] private AttackHendel _attackHendel;

    private void Start()
    {
        _detector.StartDetection();
    }

    private void OnEnable()
    {
        _detector.Detected += _movmentHendel.StartFolowing;
        _detector.Detected += _attackHendel.StartAttack;
    }

    private void OnDisable()
    {
        _detector.Detected -= _movmentHendel.StartFolowing;
        _detector.Detected -= _attackHendel.StartAttack;
    }
}