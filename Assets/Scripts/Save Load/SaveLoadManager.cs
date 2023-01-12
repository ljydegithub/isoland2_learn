using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    private string jsonFolder;

    private List<ISaveable> saveableList = new List<ISaveable>();

    private GameSaveData gameData = new GameSaveData();

    // public Dictionary<string, GameSaveData> saveDataDict = new Dictionary<string, GameSaveData>();

    protected override void Awake()
    {
        base.Awake();
        jsonFolder = Application.persistentDataPath + "/Save/";
        Debug.Log("文件路径："+jsonFolder);
    }

    private void OnEnable()
    {
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }

    private void OnStartNewGameEvent(int obj)
    {
        var resultPath = jsonFolder + "data.sav";
        if (File.Exists(resultPath))
        {
            File.Delete(resultPath);
        }
    }

    public void Register(ISaveable saveable)
    {
        saveableList.Add(saveable);
    }

    public void Save()
    {
        gameData = new GameSaveData();
        foreach(var saveable in saveableList)
            saveable.GenerateSaveData(gameData);

        var resultPath = jsonFolder + "data.sav";
        var jsonData = JsonConvert.SerializeObject(gameData, Formatting.Indented);
        if (!File.Exists(resultPath))
            Directory.CreateDirectory(jsonFolder);
        File.WriteAllText(resultPath, jsonData);
    }


    public void Load()
    {
        var resultPath = jsonFolder + "data.sav";
        if (!File.Exists(resultPath)) return;
        var stringData = File.ReadAllText(resultPath);
        var jsonData = JsonConvert.DeserializeObject<GameSaveData>(stringData);
        foreach(var saveable in saveableList)
        {
            saveable.RestoreGameData(jsonData);
        }
    }


}
