using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Infrastrukture
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class PickUp : MonoBehaviour
    {
        public event UnityAction<PickUp> Deactivated; 

        public void Deactivate()
        {
            Deactivated?.Invoke(this);
        }
        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
