using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.States;
using Assets.Scripts.Enemy.Capabilities;
using UnityEngine;

namespace Assets.Scripts.Enemy.Transitions
{
    internal class ToPatruleStateTransition : Transition
    {
        private EnemyDetector _detector;

        private bool _onRadius = true;

        public ToPatruleStateTransition(PatruleState nextState, Transform transform , float radius) : base(nextState)
        {
            _detector = new(transform, radius);
        }

        protected override bool CanTransit() => _detector.DetectPlayer() != _onRadius;
    }
}
