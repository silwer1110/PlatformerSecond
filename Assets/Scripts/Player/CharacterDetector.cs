using Assets.Scripts.Enemy.Capabilities;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
    public class CharacterDetector : MonoBehaviour
    {
        [SerializeField] float _radius = 1f;
        [SerializeField] float _delay = 1f;

        public event UnityAction<FlyingEye> Detected;
        public event UnityAction Lost;

        private void Awake()
        {
            StartCoroutine(DetectionLoop());
        }

        private IEnumerator DetectionLoop()
        {
            Collider2D hit;

            WaitForSeconds wait = new(_delay);

            while (enabled)
            {
                hit = Physics2D.OverlapCircle(transform.position, _radius, LayerMask.GetMask("Enemy"));

                if (hit == null)
                    Lost?.Invoke();
                else if (hit.TryGetComponent(out FlyingEye target))
                    Detected?.Invoke(target);

                yield return wait;
            }
        }
    }
}
