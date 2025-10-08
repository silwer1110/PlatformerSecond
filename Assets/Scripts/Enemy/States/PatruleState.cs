using Assets.Scripts.Infrastrukture;

namespace Assets.Scripts.Enemy.States
{
    public class PatruleState : State
    {
        private readonly Patruler _patruler;

        public PatruleState(IStateChanger stateChanger, Patruler patruler): base(stateChanger)
        {
            _patruler = patruler;
        }

        public override void Enter()
        {
            _patruler.StartPatruling();
        }

        public override void Exit()
        {
            _patruler.StopPatruling();
        }
    }
}