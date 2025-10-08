using Assets.Scripts.Enemy.States;
using Assets.Scripts.Infrastrukture;

namespace Assets.Scripts.Enemy.Transitions
{
    public class ToFolowStateTransition : Transition
    {
        private readonly FlyingEye _enemy;
        private readonly Character _target;

        public ToFolowStateTransition(FolowState nextState, FlyingEye enemy, Character target) : base(nextState)
        {
            _enemy = enemy;
            _target = target;
        }

        protected override bool CanTransit() =>
            (_enemy.transform.position - _target.GetCurrentPosition().position).sqrMagnitude < _enemy.DistanceToFolow;
    }
}