using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Pool;
using UnityEngine;
using Assets.Scripts.Infrastrukture;

namespace Assets.Scripts.PikcUps.Spawner
{
    internal class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private PickUp _prefab;

        [SerializeField] private float _spawnDelay = 3f;

        [SerializeField] private int _maxpickUpsCount = 4;
        [SerializeField] private int _currentPositionIndex = 0;
        [SerializeField] private int _poolSize = 20;
        [SerializeField] private int _poolCapacity = 10;

        private ObjectPool<PickUp> _pickUps;

        private void Awake()
        {
            CreatePool();
        }

        private void Start()
        {
            StartCoroutine(SpawnLoop());
        }

        private IEnumerator SpawnLoop()
        {
            WaitForSeconds wait = new(_spawnDelay);

            while (enabled)
            {
                if (_pickUps.CountInactive < _maxpickUpsCount)
                    Init(_pickUps.Get());

                yield return wait;
            }
        }

        private void CreatePool()
        {
            _pickUps = new ObjectPool<PickUp>
                (
                createFunc: () => Instantiate(_prefab),
                actionOnGet: (pickUp) => pickUp.gameObject.SetActive(true),
                actionOnRelease: (pickUp) => pickUp.gameObject.SetActive(false),
                actionOnDestroy: (pickUp) => Destroy(pickUp.gameObject),
                defaultCapacity: _poolCapacity,
                maxSize: _poolSize
                );
        }

        private void Init(PickUp pickUp)
        {
            pickUp.Deactivated += ReturToPool;

            pickUp.SetPosition(GetSpawnPosition());
        }

        private void ReturToPool(PickUp pickUp)
        {
            _pickUps.Release(pickUp);

            pickUp.Deactivated -= ReturToPool;
        }

        private Vector2 GetSpawnPosition()
        {
            _currentPositionIndex = (_currentPositionIndex + 1) % _spawnPositions.Length;

            return _spawnPositions[_currentPositionIndex].position;
        }
    }
}
