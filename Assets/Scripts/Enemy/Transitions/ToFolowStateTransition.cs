using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.States;
using Assets.Scripts.Enemy.Capabilities;
using UnityEngine;

namespace Assets.Scripts.Enemy.Transitions
{
    internal class ToFolowStateTransition : Transition
    {
        private EnemyDetector _detector;
        private float _attackRadius;

        public ToFolowStateTransition(FolowState nextState, Transform transform, float folowingRadius, float attackRadius) : base(nextState)
        {
            _detector = new(transform, folowingRadius);
            _attackRadius = attackRadius;
        }

        protected override bool CanTransit() => _detector.DetectPlayer() && 
            _detector.GetPlayerOnRadius(_attackRadius) == null;
    }
}
