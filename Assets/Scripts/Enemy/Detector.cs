using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Detector : MonoBehaviour
    {
        public event UnityAction<Character> Detected;
        public event UnityAction Lost;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character character))
                Detected?.Invoke(character);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character character))
                Lost?.Invoke();
        }
    }
}