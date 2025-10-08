using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public class Detector : MonoBehaviour
    {
        public event UnityAction<Character> OnRadius;
        public event UnityAction OutOfRadius;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character character))
                OnRadius?.Invoke(character);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character character))
                OutOfRadius?.Invoke();
        }
    }
}