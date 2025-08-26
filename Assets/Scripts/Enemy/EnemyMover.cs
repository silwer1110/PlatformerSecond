using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _folowingSpeed = 2f;

    private float _distanceBetweenPoints = 0.01f;

    public IEnumerator MoveToTarget(Vector3 target)
    {
        while ((transform.position - target).sqrMagnitude > _distanceBetweenPoints)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            yield return null;
        }

        transform.position = target;
    }

    public IEnumerator FolowTarget(Transform tareget)
    {
        while ((transform.position - tareget.position).sqrMagnitude > _distanceBetweenPoints)
        {
            transform.position = Vector3.MoveTowards(transform.position, tareget.position, _folowingSpeed * Time.deltaTime);

            yield return null;
        }
    }
}