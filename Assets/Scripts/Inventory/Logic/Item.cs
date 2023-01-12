using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;
    
    private Vector3  vanishPoint=new Vector3(9.5f, 5, 0);
    public void ItemClicked()
    {
      
        transform.DOMove(vanishPoint, 0.5f);
        transform.DOScale(0, 0.6f).OnComplete(() =>
        {   
            gameObject.SetActive(false);
            InventoryManager.Instance.AddItem(itemName);
        });
    }
}
