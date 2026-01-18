using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class FlyingEye : MonoBehaviour
    {
        [SerializeField] private Detector _detector;
        [SerializeField] private WayHendel _wayHandel;
        [SerializeField] private EnemyAnimations _animations;

        [SerializeField] private float _currentSpeed = 2f;
        [SerializeField] private float _folowingSpeed = 2.5f;
        [SerializeField] private float _distanceBetweenPoints = 0.01f;
        [SerializeField] private float _distanceToTarget = 1f;
        [SerializeField] private float _damage = 1f;
        [SerializeField] private float _atackColdown = 3f;
        [SerializeField] private float _distanceToAtack = 0.5f;

        private IMover _mover;
        private IAtackHendeler _atackHendeler;

        private void Awake()
        {
            _mover = new Patruler(_wayHandel, _currentSpeed, _distanceBetweenPoints, transform);
        }

        private void Update()
        {
            _mover.Move();
        }

        private void OnEnable()
        {
            _detector.Detected += OnPlayerDetected;
            _detector.Lost += OnPlayerOutOfRadius;
        }

        private void OnDisable()
        {
            _detector.Detected -= OnPlayerDetected;
            _detector.Lost -= OnPlayerOutOfRadius;
        }

        private void OnPlayerOutOfRadius()
        {
            _mover = new Patruler(_wayHandel, _currentSpeed, _distanceBetweenPoints, transform);

            StopCoroutine(AttackLoop());
        }

        private void OnPlayerDetected(Character target)
        {
            _mover = new Folower(target.transform, transform, _folowingSpeed, _distanceToTarget);
            _atackHendeler = new AtackHendler(_damage, _distanceToAtack, target, transform, _animations);

            StartCoroutine(AttackLoop());
        }

        private IEnumerator AttackLoop()
        {
            WaitForSeconds wait = new(_atackColdown);

            while (true)
            {
                _atackHendeler.Atack();

                yield return wait;
            }
        }
    }
}