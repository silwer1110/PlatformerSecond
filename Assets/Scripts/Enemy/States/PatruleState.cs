using Assets.Scripts.Infrastrukture;
using Assets.Scripts.Enemy.Capabilities;    

namespace Assets.Scripts.Enemy.States
{
    public class PatruleState : State
    {
        private Patruler _patruler;

        public PatruleState(IStateChanger stateChanger, Patruler patruler) : base(stateChanger)
        {
            _patruler = patruler;
        }

        protected override void OnUpdate() => _patruler.Patrule();         
    }
}