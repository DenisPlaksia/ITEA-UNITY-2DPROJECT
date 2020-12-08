using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _settingMenu;

    [SerializeField] private Button _saveGameButton;
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _quitGameButton;
    [SerializeField] private Button _playGameButton;
    [SerializeField] private Button _settingGameButton;


    private bool _isMenuOpen;


    private void Start()
    {
        _playGameButton.onClick.AddListener(OnPlayButtonClick);
        _saveGameButton.onClick.AddListener(GameSaveLoadController.Singleton.Save);
        _loadGameButton.onClick.AddListener(GameSaveLoadController.Singleton.Load);
        _quitGameButton.onClick.AddListener(CloseGame);
        _settingGameButton.onClick.AddListener(SettingOn);
        _isMenuOpen = true;
        _panelMenu.SetActive(true);
    }

    private void OnPlayButtonClick()
    {
        CloseMenu();
    }


    private void SettingOn()
    {
        PlayerController._canMove = false;
        _settingMenu.SetActive(true);
        _panelMenu.SetActive(false);
    }


    private void CloseGame()
    {
        Application.Quit();
    }

    public void MenuOpen()
    {
        PlayerController._canMove = false;
        _panelMenu.SetActive(true);
        _isMenuOpen = !_isMenuOpen;
    }

    public void CloseMenu()
    {
        PlayerController._canMove = true;
        _panelMenu.SetActive(false);
        _isMenuOpen = !_isMenuOpen;
    }
}
