using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject _options;
    private bool _isOptionsOpen = false;

    public void StatGame()
    {
        SceneManager.LoadScene("Boot");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void ShowOptions()
    {
        _isOptionsOpen = !_isOptionsOpen;

        _options.SetActive(_isOptionsOpen);
    }
}
