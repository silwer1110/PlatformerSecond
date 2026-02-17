using UnityEngine;

namespace Assets.Scripts.Enemy.Capabilities
{
    public class Folower : MonoBehaviour
    {
        [SerializeField] private float _speed =2.5f;
        [SerializeField] private float _distanceToTarget = 1f;
        [SerializeField] private float _folowRadius = 3f;

        public float FolowRadius => _folowRadius;

        public void Folow(Transform target)
        {
            if ((transform.position - target.position).sqrMagnitude > _distanceToTarget)
                transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }
    }
}