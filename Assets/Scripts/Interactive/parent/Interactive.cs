using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;
    
    public bool isDone;

    public InteractiveName interactiveName;
    public void CheckItem(ItemName itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            isDone = true;
            // 使用这个物品,并移除物品
            OnClickedAction();
            EventHandler.CallItemUsedEvent(itemName);
            SetState();
        }
    }

    /// <summary>
    /// 默认是正确的物品的情况执行
    /// </summary>
    protected virtual void OnClickedAction()
    {
        Debug.Log("正确点击");
    }

    public virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }

    public void SetState()
    {
        if (ObjectManager.Instance.InteractiveStateDict.ContainsKey(interactiveName))
            ObjectManager.Instance.InteractiveStateDict[interactiveName] = isDone;
        else
            ObjectManager.Instance.InteractiveStateDict.Add(interactiveName,isDone);
    }
    
}
