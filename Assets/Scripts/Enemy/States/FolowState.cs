using Assets.Scripts.Infrastrukture;

namespace Assets.Scripts.Enemy.States
{
    public class FolowState : State
    {
        private Folower _folower;
        private FlyingEye _flyingEye;

        public FolowState(IStateChanger stateChanger,FlyingEye flyingEye, Folower folower) : base(stateChanger)
        {
            _flyingEye = flyingEye;
            _folower = folower;
        }

        protected override void OnUpdate() => _folower.Folow(_flyingEye.Detector.GetPlayerPosition());
    }
}