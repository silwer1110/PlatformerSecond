using UnityEngine;
using Assets.Scripts.Infrastrukture;

public class Crystal : PickUp
{
    [SerializeField] private int _crystalPoints = 1;

    public int GetPoints()
    {
        return _crystalPoints;
    }
}