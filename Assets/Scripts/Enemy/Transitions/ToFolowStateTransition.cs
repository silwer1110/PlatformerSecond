using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.States;

namespace Assets.Scripts.Enemy.Transitions
{
    internal class ToFolowStateTransition : Transition
    {
        FlyingEye _flyingEye;

        public ToFolowStateTransition(FolowState nextState, FlyingEye flyingEye) : base(nextState)
        {
           _flyingEye = flyingEye;
        }

        protected override bool CanTransit() => _flyingEye.Detector.DetectPlayer();
    }
}
