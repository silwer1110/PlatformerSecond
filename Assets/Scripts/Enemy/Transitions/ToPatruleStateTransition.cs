using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.States;

namespace Assets.Scripts.Enemy.Transitions
{
    internal class ToPatruleStateTransition : Transition
    {
        private FlyingEye _flyingEye;

        public ToPatruleStateTransition(PatruleState nextState, FlyingEye flyingEye) : base(nextState)
        {
            _flyingEye = flyingEye;
        }

        protected override bool CanTransit() => !_flyingEye.Detector.DetectPlayer();
    }
}
