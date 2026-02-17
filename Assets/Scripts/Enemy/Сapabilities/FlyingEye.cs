using Assets.Scripts.Enemy.Сapabilities;
using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.Enemy.Capabilities
{
    [RequireComponent(typeof(StateMachineFactory))]
    public class FlyingEye : MonoBehaviour
    {
        [SerializeField] private WayHendel _wayHandel;
        [SerializeField] private EnemyAnimations _animations;
        [SerializeField] private Combat _combat;
        [SerializeField] private Folower _folower;
        [SerializeField] private Patruler _patruler;
        [SerializeField] private EnemyHealtView _healthView;

        private StateMachine _stateMachine;

        public EnemyHealtView HealthView => _healthView;    

        private void Awake()
        {
            _stateMachine = GetComponent<StateMachineFactory>().Create(this, _patruler, _folower, _combat);
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}