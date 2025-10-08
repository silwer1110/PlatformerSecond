using Assets.Scripts.Infrastrukture;

namespace Assets.Scripts.Enemy.States
{
    public class FolowState : State
    {
        private readonly Character _target;
        private readonly Folower _folower;

        public FolowState(IStateChanger changer, Character target, Folower folower) : base(changer) 
        {
            _target = target;
            _folower = folower;
        }

        public override void Enter()
        {
            _folower.StartFolow(_target.GetCurrentPosition());   
        }

        public override void Exit() 
        {
            _folower.StopFolow();
        }
    }
}