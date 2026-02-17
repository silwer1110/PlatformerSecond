using Assets.Scripts.Infrastrukture;
using Assets.Scripts.MedKit;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Collector : MonoBehaviour
{
    public event UnityAction<int> CrystalsCountChange;
    public event UnityAction<float> HealthCountChange;

    private int _crystalsCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PickUp pickUp))
        {
            if (pickUp is Crystal crystal)
                PickUpCrystal(crystal);
            else if (pickUp is MedKit medKit)
                PickUpMedKit(medKit);
        }
    }

    private void PickUpCrystal(Crystal crystal)
    {
        crystal.Deactivate();

        _crystalsCount += crystal.GetPoints();

        CrystalsCountChange?.Invoke(_crystalsCount);
    }

    private void PickUpMedKit(MedKit medKit)
    {
        medKit.Deactivate();

        HealthCountChange?.Invoke(medKit.Heal());
    }
}