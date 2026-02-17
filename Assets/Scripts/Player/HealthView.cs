using UnityEngine;

namespace Assets.Scripts.Player
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Collector _collector;

        private float _currentHealth = 5f;
        private float _maxhealth = 5f;
        private float _minhealth = 0f;

        public float Health => _currentHealth;

        private void OnEnable()
        {
            _collector.HealthCountChange += Heal;
        }

        private void OnDisable()
        {
            _collector.HealthCountChange -= Heal;
        }

        public void TakeDamage(float damage)
        {
            if (_currentHealth > _minhealth)
                _currentHealth -= damage;
        }

        private void Heal(float healAmount)
        {
            if (_currentHealth + healAmount <= _maxhealth)
                _currentHealth += healAmount;
            else if (_currentHealth + healAmount > _maxhealth)
                _currentHealth = _maxhealth;
        }
    }
}
