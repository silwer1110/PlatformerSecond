using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _detectionRadius = 1f;
    [SerializeField] private float _delay = 1f;

    public event UnityAction<Character> Detected;

    public void StartDetection()
    {
        StartCoroutine(DetectionLoop());
    }

    private IEnumerator DetectionLoop()
    {
        WaitForSeconds wait = new(_delay);

        Collider2D hit;

        while (enabled)
        {
            hit = Physics2D.OverlapCircle(transform.position, _detectionRadius, _layerMask);

            if (hit != null && hit.TryGetComponent(out Character character))
            {
                Detected?.Invoke(character);

                yield break;
            }

            yield return wait;
        }
    }
}