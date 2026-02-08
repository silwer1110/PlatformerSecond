using Assets.Scripts.Infrastrukture;

namespace Assets.Scripts.Enemy.States
{
    internal class CombatState : State
    {
        private Combat _combat;

        public CombatState(IStateChanger stateChanger, Combat combat) : base(stateChanger)
        {
            _combat = combat;
        }

        public override void Enter()
        {
            _combat.Atack(_combat.GetTargetOnAtackRadius());
        }   
    }
}