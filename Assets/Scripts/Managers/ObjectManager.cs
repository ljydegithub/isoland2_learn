using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>, ISaveable
{
    private Dictionary<ItemName, bool> itemAvailableDict = new Dictionary<ItemName, bool>();

    public Dictionary<ItemName, bool> ItemAvailableDict
    {
        get => itemAvailableDict;
        set => itemAvailableDict = value;
    }
    private Dictionary<InteractiveName, bool> interactiveStateDict = new Dictionary<InteractiveName, bool>();

    public Dictionary<InteractiveName, bool> InteractiveStateDict
    {
        get => interactiveStateDict;
        set => interactiveStateDict = value;
    }

    private void Start()
    {
        ISaveable saveable = this;
        saveable.SavableRegister();
    }

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }
    
    private void OnStartNewGameEvent(int obj)
    {
        itemAvailableDict.Clear();
        interactiveStateDict.Clear();
    }

    private void OnBeforeSceneUnloadEvent()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
                itemAvailableDict.Add(item.itemName, true);
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.interactiveName))
                interactiveStateDict[item.interactiveName] = item.isDone;
            else
                interactiveStateDict.Add(item.interactiveName, item.isDone);
        }
    }

    private void OnAfterSceneLoadedEvent()
    {
        // 如果已经在字典中则更新显示状态，不在则添加
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
                itemAvailableDict.Add(item.itemName, true);
            else
                item.gameObject.SetActive(itemAvailableDict[item.itemName]);
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.interactiveName))
                item.isDone = interactiveStateDict[item.interactiveName];
            else
                interactiveStateDict.Add(item.interactiveName, item.isDone);
        }
    }

    public void SavableRegister()
    {
        SaveLoadManager.Instance.Register(this);
    }

    public GameSaveData GenerateSaveData(GameSaveData saveData)
    {
        saveData.itemAvailableDict = this.itemAvailableDict;
        saveData.interactiveStateDict = this.interactiveStateDict;
        return saveData;
    }

    public void RestoreGameData(GameSaveData saveData)
    {
        this.itemAvailableDict = saveData.itemAvailableDict;
        this.interactiveStateDict = saveData.interactiveStateDict;
    }
}