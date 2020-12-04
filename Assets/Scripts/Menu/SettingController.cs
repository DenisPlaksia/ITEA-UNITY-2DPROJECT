using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private Button _saveNameButton;
    [SerializeField] private Slider _soundVolume;
    [SerializeField] private Button _menuReturn;

    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _settingMenu;

    private void Start()
    {
        _saveNameButton.onClick.AddListener(OnNameChanged);
        _soundVolume.onValueChanged.AddListener(SoundController.Singelton.ChangeVolume);
        _menuReturn.onClick.AddListener(MenuBack);
        _soundVolume.onValueChanged.AddListener(SoundChange);
    }

    private void OnNameChanged()
    {
        Player.Singleton.SetName(_nameInputField.text);
    }

    private void MenuBack()
    {
        PlayerController._canMove = false;
        _settingMenu.SetActive(false);
        _panelMenu.SetActive(true);
    }

    private void SoundChange(float volume)
    {
        SoundController.Singelton.ChangeVolume(volume);
    }
}
