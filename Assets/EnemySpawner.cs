using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyList;
    [SerializeField] private List<Transform> _spawnPoints;
    private ObjectPool<GameObject> _pool;
    [SerializeField] private int _defaultSize;
    [SerializeField] private int _maxSize;
    private Action _onBeatAction;

    private void Awake()
    {
        Init();
        _maxSize = 10000;
    }

    private void Init()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: InstantiatedEnemy,
            actionOnGet: GetEnemy,
            actionOnRelease: ReleaseEnemy,
            actionOnDestroy: DestroyEnemy,
            collectionCheck: true,
            defaultCapacity: _defaultSize,
            maxSize: _maxSize
        );
    }

    private void DestroyEnemy(GameObject enemyBase)
    {
        Destroy(enemyBase.gameObject);
    }

    private void ReleaseEnemy(GameObject enemyBase)
    {
        enemyBase.gameObject.SetActive(false);
    }

    private void GetEnemy(GameObject enemyBase)
    {
        enemyBase.gameObject.SetActive(true);
        var random = Random.Range(0, _spawnPoints.Count);
        enemyBase.transform.position = _spawnPoints[random].position;
        enemyBase.transform.rotation = _spawnPoints[random].rotation;
    }

    private GameObject InstantiatedEnemy()
    {
        var enemyIndex = Random.Range(0, _enemyList.Count);
        var obj = Instantiate(_enemyList[enemyIndex]);
        return obj;
    }
    
    private void DebugWave()
    {
        var random = Random.Range(0, 10);
        for (int i = 0; i < random; i++)
        {
            _pool.Get();
        }
    }

}
    