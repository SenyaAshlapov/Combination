using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public delegate void MenuAction(bool value);

    public static MenuAction PlayerLockMovment;
    private PlayerInput _playerInput;

    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _gamePlayUI;

    [SerializeField] private GameObject _options;

    private bool _isOptionsOpen = false;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.pause.performed += context => showMenu();


    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void showMenu()
    {

        PlayerLockMovment?.Invoke(false);

        _menu.SetActive(true);
        _hud.SetActive(false);
        _gamePlayUI.SetActive(false);
        Time.timeScale = 0.03f;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        PlayerLockMovment?.Invoke(true);

        _hud.SetActive(true);
        _menu.SetActive(false);
        _gamePlayUI.SetActive(true);        
    }

    public void RestartGame() 
    {
        Time.timeScale = 1;
        PlayerLockMovment?.Invoke(false);

        SceneManager.LoadScene("GameScene");
    }

    public void ShowOptions() 
    { 
        _isOptionsOpen = !_isOptionsOpen;

        _options.SetActive(_isOptionsOpen);
    }

    public void LeaveGame()
    {
        Time.timeScale = 1;
        PlayerLockMovment?.Invoke(false);

        SceneManager.LoadScene("Menu");
    }
}
