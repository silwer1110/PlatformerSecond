using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(StateMachineFactory))]
    public class FlyingEye : MonoBehaviour
    {
        [SerializeField] private WayHendel _wayHandel;
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private Combat _combat;

        [SerializeField] private float _currentSpeed = 2f;
        [SerializeField] private float _folowingSpeed = 2.5f;
        [SerializeField] private float _distanceBetweenPoints = 0.01f;
        [SerializeField] private float _distanceToTarget = 1f;
        [SerializeField] private float _detectionRadius = 3f;

        private StateMachine _stateMachine;
        private Patruler _patruler;
        private Folower _folower;

        public Detector Detector { get; private set; }

        private void Awake()
        {
            Detector = new(transform, _detectionRadius);
            _patruler = new(_wayHandel, _currentSpeed, _distanceBetweenPoints, transform);
            _folower = new(transform, _folowingSpeed, _distanceToTarget);
            _stateMachine = GetComponent<StateMachineFactory>().Create(this, _patruler, _folower, _combat);
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}