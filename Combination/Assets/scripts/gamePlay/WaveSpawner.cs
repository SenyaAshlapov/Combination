using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private WaveSpawnData _curentWaveData;
    [SerializeField] private WaveSpawnData _testWaveData;

    [SerializeField] private List<Transform> _enemySpawnPoints = new List<Transform>();

    [SerializeField] private float _restTime;
    private int _waveID = 0;
    [SerializeField]private int _enemyPool;

    [SerializeField]private int _score  = 0;
    [SerializeField]private float _spawnRange;
    private void Start()
    {
        GetWaveData(_testWaveData);
    }

    private void Awake()
    {
        Enemy.EnemyDying += removeEnemy;
    }

    private void OnDestroy()
    {
        Enemy.EnemyDying -= removeEnemy;
    }

    public void GetWaveData(WaveSpawnData newWaveData)
    {
        _curentWaveData = newWaveData;
        startWave();
    }

    private void startWave()
    {
        _enemyPool = _curentWaveData.WaveList[_waveID].Count;

        foreach (Transform point in _enemySpawnPoints)
        {

            spawnEnemy();
        }
    }


    private void removeEnemy()
    {
       _score += 1;


        if (_score <= (_enemyPool - _enemySpawnPoints.Count))
            spawnNewEnemy();

        else if ( _score == _enemyPool)
        {
            updateWave();
        }

    }

    private void spawnNewEnemy()
    {
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        int randomEnemy = Random.Range(0, _curentWaveData.WaveList[_waveID].Enemies.Length);

        int randomSpawnPoint = Random.Range(0, _enemySpawnPoints.Count);

        
        Vector3 randomSpawn = new Vector3(Random.Range(0, _spawnRange), 0, Random.Range(0, _spawnRange));

        Debug.Log(randomSpawnPoint);

        Instantiate(
            _curentWaveData.WaveList[_waveID].Enemies[randomEnemy],
            _enemySpawnPoints[randomSpawnPoint].position + randomSpawn,
            _enemySpawnPoints[randomSpawnPoint].rotation);
    }

    private void updateWave()
    {
        StartCoroutine((IEupdateSpawner()));
    }

    private IEnumerator IEupdateSpawner()
    {
        _waveID += 1;
        Debug.Log("update");
        yield return new WaitForSeconds(_restTime);
        _score = 0;
        startWave();
        yield return null;
    }


}
