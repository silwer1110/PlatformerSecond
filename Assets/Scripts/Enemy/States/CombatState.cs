using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.Capabilities;

namespace Assets.Scripts.Enemy.States
{
    internal class CombatState : State
    {
        private Combat _combat;

        public CombatState(IStateChanger stateChanger, Combat combat) : base(stateChanger)
        {
            _combat = combat;
        }

        protected override void OnUpdate()
        {
            if(_combat.IsAttacking)
                return;

            _combat.StartAttacking();
        }

        public override void Exit()
        {
            _combat.StopAttack();
        }
    }
}