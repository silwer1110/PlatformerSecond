using Assets.Scripts.Enemy.States;
using Assets.Scripts.Enemy.Transitions;
using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    internal class StateMachineFactory : MonoBehaviour 
    {
        public StateMachine Create(FlyingEye flyingEye, Patruler patruler, Folower folower, Combat combat)
        {
            var stateMachine = new StateMachine();

            PatruleState patruleState = new(stateMachine, patruler);
            FolowState folowState = new(stateMachine, flyingEye, folower);
            CombatState combatState = new(stateMachine, combat);

            ToPatruleStateTransition toPatruleStateTransition = new(patruleState, flyingEye); 
            ToFolowStateTransition toFolowStateTransition = new(folowState, flyingEye);
            ToCombatStateTransition toCombatStateTransition = new(combatState, combat);

            patruleState.AddTransition(toFolowStateTransition);
            folowState.AddTransition(toPatruleStateTransition);
            folowState.AddTransition(toCombatStateTransition);
            combatState.AddTransition(toFolowStateTransition);

            stateMachine.ChangeState(patruleState);

            return stateMachine;
        }
    }
}