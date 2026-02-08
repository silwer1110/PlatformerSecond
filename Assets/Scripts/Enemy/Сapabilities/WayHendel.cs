using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class WayHendel : MonoBehaviour
    {
        [SerializeField] private Transform[] _waypoints;

        private int _currentIndex = 0;

        public Vector2 GetNextPosition()
        {
            _currentIndex = ++_currentIndex % _waypoints.Length;

            return _waypoints[_currentIndex].position;
        }
    }
}