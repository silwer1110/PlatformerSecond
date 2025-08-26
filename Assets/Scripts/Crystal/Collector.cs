using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Rigidbody2D))]
public class Collector : MonoBehaviour
{
    public event UnityAction<int> CrystalsCountChange;

    private int _crystalsCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            crystal.Deactivate();

            _crystalsCount += crystal.GetPoints();

            CrystalsCountChange?.Invoke(_crystalsCount);
        }
    }
}