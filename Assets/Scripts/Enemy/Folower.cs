using System.Collections;
using UnityEngine;

public class Folower : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    public IEnumerator Folow(Transform target)
    {
        while (enabled)
        {
            yield return _enemyMover.FolowTarget(target);
        }
    }
}