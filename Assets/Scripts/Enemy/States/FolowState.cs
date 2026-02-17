using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.Capabilities;

namespace Assets.Scripts.Enemy.States
{
    public class FolowState : State
    {
        private Folower _folower;
        EnemyDetector _detector;

        public FolowState(IStateChanger stateChanger, Folower folower) : base(stateChanger)
        {
            _folower = folower;
            _detector = new(folower.transform, folower.FolowRadius);
        }

        protected override void OnUpdate() => _folower.Folow(_detector.GetPlayerOnRadius(_folower.FolowRadius).transform);
    }
}