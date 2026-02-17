using UnityEngine;

namespace Assets.Scripts.Enemy.Сapabilities
{
    public class EnemyHealtView: MonoBehaviour
    {
        private float _currentHealth = 5f;
        private float _minhealth = 0f;

        public float Health => _currentHealth;  

        public void TakeDamage(float damage)
        {
            if (_currentHealth > _minhealth)
                _currentHealth -= damage;
        }
    }
}
