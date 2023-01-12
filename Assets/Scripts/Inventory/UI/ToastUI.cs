using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToastUI : Singleton<ToastUI>
{
    public GameObject toast;

    private Coroutine show;
    public void ShowToast(string itemText)
    {
        if (show!=null)
            StopCoroutine(show);
        show = StartCoroutine(ShowToastIEnumerator(itemText));
    }

    private IEnumerator ShowToastIEnumerator(string itemText)
    {
        toast.SetActive(true);
        toast.GetComponentInChildren<Text>().text = itemText;
        yield return new WaitForSeconds(2);
        toast.SetActive(false);
        show = null;
    }
}