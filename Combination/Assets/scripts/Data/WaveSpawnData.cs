using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveSpawnData", menuName = "Combination/WaveSpawnData", order = 0)]
public class WaveSpawnData : ScriptableObject
{
    public string Difficulty;
    public List<WaveData> WaveList = new List<WaveData>();


}

[System.Serializable]
public struct WaveData{
    public int Count;
    public Enemy[] Enemies;
}