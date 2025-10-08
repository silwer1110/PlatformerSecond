using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(StateMachineFactory))]
    public class FlyingEye : MonoBehaviour
    {
        [SerializeField] private MovmentHandel _movmentHandel;
        [SerializeField] private Detector _detector;

        private StateMachine _stateMachine;
        private float _distanceToFolow = 1f;

        public MovmentHandel MovmentHandel => _movmentHandel;
        public float DistanceToFolow => _distanceToFolow;

        private void OnEnable()
        {
            _detector.OnRadius += Initalize;
        }

        private void OnDisable()
        {
            _detector.OnRadius -= Initalize;
        }

        private void Update()
        {
            _stateMachine?.Update();
        }

        private void Initalize(Character target)
        {
            _stateMachine = GetComponent<StateMachineFactory>().Create(this, target);
        }
    }
}