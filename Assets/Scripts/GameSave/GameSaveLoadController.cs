using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveLoadController : MonoBehaviour
{

    private const string PlayerDataFilePath = @"C:\Users\Professional\Desktop\ITEA-UNITY-2DPROJECT\Save";
    private const string PlayerDataKey = "PlayerData";

    public static GameSaveLoadController Singleton { get; private set; }

    public void Awake()
    {
        Singleton = this;
    }

    public void Save()
    {
        var jsonObject = JsonUtility.ToJson(Player.Singleton.playerData, true);

        PlayerPrefs.SetString(PlayerDataKey, jsonObject);

        Debug.Log($"SavePlayerData to path: {PlayerDataFilePath}, playerData: {jsonObject}");

    }

    public void Load()
    {
        //load from file
        if (!File.Exists(PlayerDataFilePath))
        {
            Debug.LogError($"File did not found at path: {PlayerDataFilePath}");
            return;
        }

        string jsonObject = string.Empty;

        jsonObject = PlayerPrefs.GetString(PlayerDataKey);

        Player.Singleton.playerData = JsonUtility.FromJson<PlayerData>(jsonObject);
        Player.Singleton.TakeCoins(Player.Singleton.playerData.Score);
        Debug.Log($"Load PlayerData from path: {PlayerDataFilePath}, playerData: {jsonObject}");
    }
}
