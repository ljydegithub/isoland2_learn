using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeUI : MonoBehaviour
{
    public GameObject panel;
    public GameObject maks;
    public Text dialogueText;

    public GameObject menu, holder;
    
    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += OnShowDialogue;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= OnShowDialogue;
    }
    
    private void OnShowDialogue(string dialogue)
    {
        StartCoroutine(WaitExecute(dialogue));
    }

    private IEnumerator WaitExecute(string dialogue)
    {
        yield return new WaitForSeconds(0.01f);
        if (dialogue != string.Empty)
        {
            panel.SetActive(true);
            menu.SetActive(false);
            holder.SetActive(false);
            maks.GetComponent<BoxCollider2D>().enabled = true;
            maks.GetComponent<Image>().enabled = true;
        }
        else
        {
            panel.SetActive(false);
            menu.SetActive(true);
            holder.SetActive(true);
            maks.GetComponent<BoxCollider2D>().enabled = false;
            maks.GetComponent<Image>().enabled = false;
        }
        dialogueText.text = dialogue;
        // this.GetComponent<VerticalLayoutGroup>()
    }
    

}
