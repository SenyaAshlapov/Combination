using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisher : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompleteWindow;
    [SerializeField] private GameObject _levelFailedhWindow;


    private void Awake()
    {
        Player.PlayerDying += levelFailed;
        WaveSpawner.GameComplete += levelComplete;
    }

    private void OnDestroy()
    {
        Player.PlayerDying -= levelFailed;
        WaveSpawner.GameComplete -= levelComplete;
    }
    private void levelComplete()
    {
        _levelCompleteWindow.SetActive(true);
    }

    private void levelFailed()
    {
        _levelFailedhWindow.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LeaveLevel()
    {
        SceneManager.LoadScene("Menu");
    }
}
