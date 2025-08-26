using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CrystalsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private float _spawnDelay = 3f;
    [SerializeField] private Crystal _prefab;

    private int _maxCrystlsCount = 4;
    private int _currentPositionIndex = 0;
    private ObjectPool<Crystal> _crystals;
    private int _poolSize = 20;
    private int _poolCapacity = 10;

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
            if (_crystals.CountInactive < _maxCrystlsCount)
                Init(_crystals.Get());

            yield return wait;
        }
    }

    private void CreatePool()
    {
        _crystals = new ObjectPool<Crystal>
            (
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (cube) => cube.gameObject.SetActive(true),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            defaultCapacity: _poolCapacity,
            maxSize: _poolSize
            );
    }
    private void Init(Crystal crystal)
    {
        crystal.Deactivated += ReturToPool;

        crystal.SetPosition(GetSpawnPosition());
    }

    private void ReturToPool(Crystal crystal)
    {
        _crystals.Release(crystal);

        crystal.Deactivated -= ReturToPool;
    }

    private Vector2 GetSpawnPosition()
    {
        _currentPositionIndex = (_currentPositionIndex + 1) % _spawnPositions.Length;

        return _spawnPositions[_currentPositionIndex].position;
    }
}