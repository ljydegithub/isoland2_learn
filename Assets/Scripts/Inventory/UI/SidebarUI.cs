using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SidebarUI : Singleton<SidebarUI>
{
    public Button item;
    public GameObject content;
    
    private ItemDetails currentDetails;

    private Dictionary<ItemName, Button> itemDict = new Dictionary<ItemName, Button>();
    
    private void OnEnable()
    {
        EventHandler.AddItemToRight += OnAddItemToRight;
        EventHandler.RemoveItemInRight += OnRemoveItemInRight;
    }

    private void OnDisable()
    {
        EventHandler.AddItemToRight -= OnAddItemToRight;
        EventHandler.RemoveItemInRight -= OnRemoveItemInRight;
    }

    private void OnAddItemToRight(ItemDetails itemDetails)
    {
        if (!itemDict.ContainsKey(itemDetails.itemName))
        {
            Button tool = Instantiate(item, content.transform, true);
            Image btnImage =tool.transform.GetChild(0).GetComponent<Image>();
            btnImage.sprite= itemDetails.itemSprite;
            // btnImage.SetNativeSize();
        
            tool.onClick.AddListener(() =>
            {
                EventHandler.CallItemSelectedEvent(itemDetails, true);
                currentDetails = itemDetails;
                ToastUI.Instance.ShowToast(itemDetails.itemText);
            });
            itemDict.Add(itemDetails.itemName, tool);
            ObjectManager.Instance.ItemAvailableDict[itemDetails.itemName] = false;
        }
    }

    private void OnRemoveItemInRight(ItemName itemName)
    {
        // ItemName key = itemDetails.itemName;
        if (itemDict.ContainsKey(itemName))
        {
            Destroy(itemDict[itemName].gameObject);
            itemDict.Remove(itemName);
        }
    }

    public void RemoveAllItem()
    {
        if (content.transform.childCount > 0)
            for (int i = 0; i < content.transform.childCount; i++)
                Destroy(content.transform.GetChild(i).gameObject);
        itemDict.Clear();
    }
    public void OnEmptyClick()
    {
        EventHandler.CallItemSelectedEvent(currentDetails, false);
    }
    
}