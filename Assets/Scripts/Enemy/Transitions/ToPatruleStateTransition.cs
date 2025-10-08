using Assets.Scripts.Enemy.States;
using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.Enemy.Transitions
{
    public class ToPatruleStateTransition : Transition
    {
        private readonly FlyingEye _enemy;
        
        public ToPatruleStateTransition(PatruleState nextState,FlyingEye enemy) : base(nextState)
        {
            _enemy = enemy;
        }

        protected override bool CanTransit() => 
            Vector2.Distance(_enemy.transform.position, _enemy.MovmentHandel.WayHendel.GetNextPosition()) > 0.1f;
    }
}