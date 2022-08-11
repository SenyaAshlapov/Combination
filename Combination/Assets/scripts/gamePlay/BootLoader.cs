using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    private SavesManager _savesManager = new SavesManager();

    [SerializeField]private string _gameScene;
    [SerializeField]private GameObject _loadScrene;
    public void loadLevelWitDifficulty(string difficulty)
    {
        _savesManager.SaveDifficulty(difficulty);
        _loadScrene.SetActive(true);

        StartCoroutine(IEloadAsyncScene(_gameScene));
    }

    private IEnumerator IEloadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
