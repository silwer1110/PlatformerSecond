using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.States;
using Assets.Scripts.Enemy.Capabilities;
using UnityEngine;

namespace Assets.Scripts.Enemy.Transitions
{
    internal class ToCombatStateTransition : Transition
    {
        private EnemyDetector _detector;

        public ToCombatStateTransition(CombatState nextState, Transform transform ,float atackRadius) : base(nextState)
        {
            _detector = new(transform, atackRadius);
        }

        protected override bool CanTransit() => _detector.DetectPlayer();
    }
}
