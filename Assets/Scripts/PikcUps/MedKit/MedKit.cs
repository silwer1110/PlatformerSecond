using Assets.Scripts.Infrastrukture;
using UnityEngine;

namespace Assets.Scripts.MedKit
{
    public class MedKit : PickUp
    {
        [SerializeField] private float _healthPoints = 3f;

        public float Heal()
        {
            return _healthPoints;
        }
    }
}
