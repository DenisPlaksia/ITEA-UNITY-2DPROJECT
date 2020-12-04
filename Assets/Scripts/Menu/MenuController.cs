using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    private const string PlayerDataFilePath = @"C:\Users\Professional\Desktop\ITEA-UNITY-2DPROJECT\Save";
    private const string PlayerDataKey = "PlayerData";

    private void Start()
    {
        _playGameButton.onClick.AddListener(OnPlayButtonClick);
        _saveGameButton.onClick.AddListener(Save);
        _loadGameButton.onClick.AddListener(Load);
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

    private void Save()
    {
        var jsonObject = JsonUtility.ToJson(Player.Singleton._playerData, true);

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

        jsonObject = PlayerPrefs.GetString(PlayerDataKey);

        Player.Singleton._playerData = JsonUtility.FromJson<PlayerData>(jsonObject);
        Player.Singleton.TakeCoins(Player.Singleton._playerData._score);
        Debug.Log($"Load PlayerData from path: {PlayerDataFilePath}, playerData: {jsonObject}");
    }
}
