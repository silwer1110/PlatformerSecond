using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Folower : MonoBehaviour
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private float _folowingSpeed = 2f;
        [SerializeField] private float _distanceToTarget = 0.5f;

        private Coroutine _coroutine;

        public void StartFolow(Transform target)
        {
            _coroutine = StartCoroutine(FolowTarget(target));
        }

        public void StopFolow()
        {
            StopCoroutine(_coroutine);
        }

        public IEnumerator FolowTarget(Transform tareget)
        {
            while ((transform.position - tareget.position).sqrMagnitude > _distanceToTarget)
            {
                transform.position = Vector3.MoveTowards(transform.position, tareget.position, _folowingSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}