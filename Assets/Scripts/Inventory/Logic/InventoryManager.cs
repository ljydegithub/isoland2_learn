using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>,ISaveable
{

    public ItemDataList_SO itemData;

    [SerializeField]private List<ItemName> itemList = new List<ItemName>();

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }
    
    private void OnStartNewGameEvent(int obj)
    {
        itemList.Clear();
        SidebarUI.Instance.RemoveAllItem();
    }
    
    private void OnItemUsedEvent(ItemName itemName)
    {
        int index = GetItemIndex(itemName);
        itemList.RemoveAt(index);
        
        EventHandler.CallRemoveItemInRight(itemName);
        // TODO:暂时实现单一物品使用效果
    }

    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            EventHandler.CallAddItemToRight(itemData.GetItemDetails(itemName));
        }
    }

    private int GetItemIndex(ItemName itemName)
    {
        for (int i = 0; i < itemList.Count; i++)
            if (itemList[i] == itemName)
                return i;
        return -1;
    }
    private void Start()
    {
        ISaveable saveable = this;
        saveable.SavableRegister();
    }
    public void SavableRegister()
    {
        SaveLoadManager.Instance.Register(this);
    }
    
    public GameSaveData GenerateSaveData(GameSaveData saveData)
    {
        saveData.itemList = this.itemList;
        SidebarUI.Instance.RemoveAllItem();
        return saveData;
    }
    
    public void RestoreGameData(GameSaveData saveData)
    {
        foreach (var itemName in saveData.itemList)
            EventHandler.CallAddItemToRight(itemData.GetItemDetails(itemName));
        this.itemList = saveData.itemList;
    }
}
