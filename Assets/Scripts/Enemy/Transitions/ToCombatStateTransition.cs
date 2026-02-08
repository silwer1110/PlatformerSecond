using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.States;

namespace Assets.Scripts.Enemy.Transitions
{
    internal class ToCombatStateTransition : Transition
    {
        private Combat _combat;  

        public ToCombatStateTransition(CombatState nextState, Combat combat) : base(nextState)
        {
            _combat = combat;
        }

        protected override bool CanTransit() => _combat.GetTargetOnAtackRadius() != null;
    }
}
