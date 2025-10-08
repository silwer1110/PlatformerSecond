using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Patruler : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private WayHendel _wayHendel;

        private Coroutine _coroutine;

        public void StartPatruling()
        {
            _coroutine = StartCoroutine(MoveLoop());
        }

        public void StopPatruling() 
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator MoveLoop()
        {
            Vector2 position = _wayHendel.GetNextPosition();

            while (enabled)
            {
                yield return _mover.MoveToTarget(position);

                position = _wayHendel.GetNextPosition();
            }
        }
    }
}