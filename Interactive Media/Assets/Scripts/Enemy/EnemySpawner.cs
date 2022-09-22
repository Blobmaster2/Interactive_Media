using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float _minSpawnTime;
    public float _maxSpawnTime;
    
    public int _minSpawnCount;
    public int _maxSpawnCount;

    Transform _spawnpoint;
    public GameObject _enemyPrefab;
    GameObject _enemyCount;

    bool _doSpawn = true;

    private void Start()
    {
        _spawnpoint = transform;
        _enemyCount = GameObject.Find("Enemies");
    }

    // Update is called once per frame
    void Update()
    {
        if (_doSpawn && _enemyCount.transform.childCount < 50) Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < Random.Range(_minSpawnCount, _maxSpawnCount); i++)
        { 
            var enemy = Instantiate(_enemyPrefab, _spawnpoint.position + new Vector3(i + 0.5f, 0.6f, i), Quaternion.Euler(0, 0, 0));
            enemy.transform.parent = _enemyCount.transform;
        }
        
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        _doSpawn = false;

        yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));

        _doSpawn = true;
    }


}
