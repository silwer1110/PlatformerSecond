using Assets.Scripts.Enemy.States;
using Assets.Scripts.Enemy.Transitions;
using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Infrastrukture
{
    public class StateMachineFactory : MonoBehaviour
    {
        public StateMachine Create(FlyingEye enemy, Character character)
        {
            StateMachine stateMachine = new();

            PatruleState patruleState = new(stateMachine, enemy.MovmentHandel.Patruler);
            FolowState folowState = new(stateMachine, character, enemy.MovmentHandel.Folower);

            ToPatruleStateTransition toPatruleStateTransition = new(patruleState, enemy);
            ToFolowStateTransition toFolowStateTransition = new(folowState, enemy, character);

            patruleState.AddTransition(toFolowStateTransition);
            folowState.AddTransition(toPatruleStateTransition);

            stateMachine.ChangeState(patruleState);

            return stateMachine;
        }
    }
}