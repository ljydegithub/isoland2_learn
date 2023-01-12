using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskClick : Singleton<MaskClick>
{
    private DialogueController dialogueController;
    private bool isDone;
    public void OnClickMask(DialogueController dialogueController,bool isFinish,bool isNew)
    {
        if (isNew)
        {
            this.dialogueController = dialogueController;
            this.isDone = isFinish;
        }
        if(this.isDone)
            this.dialogueController.ShowDialogueFinish();
        else
            this.dialogueController.ShowDialogueEmpty();
    }
}
