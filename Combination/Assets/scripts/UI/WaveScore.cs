using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _score;

    private void Awake() {
        WaveSpawner.UpdateWaveScore += updateScore;
        WaveSpawner.UpdateCurrentWaveScore += updateCurentScore;
    }
    private void updateScore(int newScore) => _score.text = newScore.ToString();
    private void updateCurentScore(int newCurrentScore) => _currentScore.text = newCurrentScore.ToString();
}
