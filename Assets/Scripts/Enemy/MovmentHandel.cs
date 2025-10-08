using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class MovmentHandel : MonoBehaviour
    {
        [SerializeField] private Folower _folower;
        [SerializeField] private Patruler _patruler;
        [SerializeField] private WayHendel _wayHendel;

        public Folower Folower => _folower;
        public Patruler Patruler => _patruler;
        public WayHendel WayHendel => _wayHendel;
    }
}