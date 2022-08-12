using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public delegate void WaveFloatAction(float value);
    public delegate void WaveIntAction(int value);
    public static WaveFloatAction ActivateTimer;
    public static WaveIntAction UpdateWaveScore;
    public static WaveIntAction UpdateCurrentWaveScore;
    public delegate void WaveAction();
    public static WaveAction WaveStart;
    public static WaveAction WaveEnd;
    [SerializeField] private WaveSpawnData _curentWaveData;
    [SerializeField] private List<WaveSpawnData> _wavesDataList = new List<WaveSpawnData>();

    [SerializeField] private List<Transform> _enemySpawnPoints = new List<Transform>();

    [SerializeField] private float _restTime;
    private int _waveID = 0;
    [SerializeField] private int _enemyPool;

    [SerializeField] private int _score = 0;
    [SerializeField] private float _spawnRange;

    private SavesManager _savesManager = new SavesManager();
    private void Start()
    {
        loadDifficulty();
        GetWaveData(_curentWaveData);
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

        UpdateCurrentWaveScore?.Invoke(_score);
        UpdateWaveScore?.Invoke(_enemyPool);

        foreach (Transform point in _enemySpawnPoints)
        {

            spawnEnemy();
        }
    }


    private void removeEnemy()
    {
        _score += 1;
        UpdateCurrentWaveScore(_score);

        if (_score <= (_enemyPool - _enemySpawnPoints.Count))

            spawnNewEnemy();

        if (_score == _enemyPool)
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

        Instantiate(
            _curentWaveData.WaveList[_waveID].Enemies[randomEnemy],
            _enemySpawnPoints[randomSpawnPoint].position + randomSpawn,
            _enemySpawnPoints[randomSpawnPoint].rotation);
    }

    private void loadDifficulty(){
        string difficulty = _savesManager.LoadDifficulty();

        foreach(WaveSpawnData data in _wavesDataList){
            if(data.Difficulty == difficulty){
                _curentWaveData = data;
            }
        }
    }

    private void updateWave()
    {
        _waveID += 1;
        if(_waveID == _curentWaveData.WaveList.Count)
        {
            Debug.Log("finish game");
        }
        else
        {
             StartCoroutine((IEupdateSpawner()));
        }
       
    }

    private IEnumerator IEupdateSpawner()
    {

        ActivateTimer?.Invoke(_restTime);
        WaveEnd?.Invoke();

        yield return new WaitForSeconds(_restTime);

        _score = 0;
        WaveStart?.Invoke();
        startWave();

        yield return null;
    }


}
