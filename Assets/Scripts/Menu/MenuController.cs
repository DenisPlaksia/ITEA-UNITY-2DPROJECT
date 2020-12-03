using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuController : MonoBehaviour
{

    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private Button _saveNameButton;
    [SerializeField] private Slider _soundVolume;
    [SerializeField] private Button _saveGameButton;
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _quitGameButton;

    [SerializeField] private Button _playGameButton;

    private bool _isMenuOpen;

    private const string PlayerDataFilePath = @"C:\Users\Professional\Desktop\ITEA-UNITY-2DPROJECT\Save";
    private const string PlayerDataKey = "PlayerData";

    private void Start()
    {
        _saveNameButton.onClick.AddListener(OnNameChanged);
        _playGameButton.onClick.AddListener(OnPlayButtonClick);
        _soundVolume.onValueChanged.AddListener(SoundController.Singelton.ChangeVolume);
        _saveGameButton.onClick.AddListener(Save);
        _loadGameButton.onClick.AddListener(Load);
        _isMenuOpen = true;
        _panelMenu.SetActive(true);
    }



    private void OnNameChanged()
    {
        Player.Singleton._name = _nameInputField.text;
        Debug.Log(Player.Singleton._name);
    }

    private void OnPlayButtonClick()
    {
        CloseMenu();
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

    private void Save()
    {
        var jsonObject = JsonUtility.ToJson(Player.Singleton, true);
        using (FileStream file = new FileStream(PlayerDataFilePath, FileMode.OpenOrCreate))
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(jsonObject);

            file.Write(array, 0, array.Length);
        }

        PlayerPrefs.SetString(PlayerDataKey, jsonObject);

        Debug.Log($"SavePlayerData to path: {PlayerDataFilePath}, playerData: {jsonObject}");

    }

    private void Load()
    {
        //load from file
        if (!File.Exists(PlayerDataFilePath))
        {
            Debug.LogError($"File did not found at path: {PlayerDataFilePath}");
            return;
        }

        string jsonObject = string.Empty;

        using (FileStream file = File.OpenRead(PlayerDataFilePath))
        {
            byte[] array = new byte[file.Length];
            file.Read(array, 0, array.Length);
            //convert to jsonObj
            jsonObject = System.Text.Encoding.Default.GetString(array);
        }
        //jsonObject = PlayerPrefs.GetString(PlayerDataKey, string.Empty);

        //convert to class object
        Player.Singleton = JsonUtility.FromJson<Player>(jsonObject);

        Debug.Log($"Load PlayerData from path: {PlayerDataFilePath}, playerData: {jsonObject}");
    }
}
