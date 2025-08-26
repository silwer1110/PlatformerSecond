using System.Collections;
using UnityEngine;

public class Patruller : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private WayHendel _wayHendel;

    public IEnumerator MoveLoop()
    {
        Vector2 position = _wayHendel.GetPosition();

        while (enabled)
        {
            yield return _enemyMover.MoveToTarget(position);

            position = _wayHendel.GetPosition();
        }
    }
}