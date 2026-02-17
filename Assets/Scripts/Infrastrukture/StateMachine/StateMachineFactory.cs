using Assets.Scripts.Enemy.States;
using Assets.Scripts.Enemy.Transitions;
using Assets.Scripts.Enemy.Capabilities;
using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    internal class StateMachineFactory : MonoBehaviour 
    {
        public StateMachine Create(FlyingEye flyingEye, Patruler patruler, Folower folower, Combat combat)
        {
            StateMachine stateMachine = new();

            PatruleState patruleState = new(stateMachine, patruler);
            FolowState folowState = new(stateMachine, folower);
            CombatState combatState = new(stateMachine, combat);

            ToPatruleStateTransition toPatruleStateTransition = new(patruleState, transform, folower.FolowRadius); 
            ToFolowStateTransition toFolowStateTransition = new(folowState, transform, folower.FolowRadius, combat.AttackRadius);
            ToCombatStateTransition toCombatStateTransition = new(combatState, transform, combat.AttackRadius);

            patruleState.AddTransition(toFolowStateTransition);
            folowState.AddTransition(toPatruleStateTransition);
            folowState.AddTransition(toCombatStateTransition);
            combatState.AddTransition(toFolowStateTransition);

            stateMachine.ChangeState(patruleState);

            return stateMachine;
        }
    }
}