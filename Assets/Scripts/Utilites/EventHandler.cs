using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action BeforeSceneUnloadEvent;

    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;

    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }


    public static event Action<ItemDetails, bool> ItemSelectedEvent;

    public static void CallItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        ItemSelectedEvent?.Invoke(itemDetails, isSelected);
    }

    public static event Action<ItemName> ItemUsedEvent;

    public static void CallItemUsedEvent(ItemName itemName)
    {
        ItemUsedEvent?.Invoke(itemName);
    }

    public static event Action<string> ShowDialogueEvent;

    public static void CallShowDialogueEvent(string dialogue)
    {
        ShowDialogueEvent?.Invoke(dialogue);
    }

    public static event Action<GameState> GameStateChangeEvent;

    public static void CallGameStateChangeEvent(GameState gameState)
    {
        GameStateChangeEvent?.Invoke(gameState);
    }

    public static event Action CheckGameStateEvent;
    public static void CallCheckGameStateEvent()
    {
        CheckGameStateEvent?.Invoke();
    }

    public static event Action<string> GamePassEvent;
    public static void CallGamePassEvent(string gameName)
    {
        GamePassEvent?.Invoke(gameName);
    }

    public static event Action<int> StartNewGameEvent;

    public static void CallStartNewGameEvent(int gameWeek)
    {
        StartNewGameEvent?.Invoke(gameWeek);
    }
    
    
    // 添加物品到侧边栏
    
    public static event Action<ItemDetails> AddItemToRight;
    public static void CallAddItemToRight(ItemDetails itemDetails)
    {
        AddItemToRight?.Invoke(itemDetails);
    }
    
    public static event Action<ItemName> RemoveItemInRight;
    public static void CallRemoveItemInRight(ItemName itemName)
    {
        RemoveItemInRight?.Invoke(itemName);
    }
}
