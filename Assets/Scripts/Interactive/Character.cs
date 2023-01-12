using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : Interactive
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        MaskClick.Instance.OnClickMask(dialogueController, isDone, true);
    }

    protected override void OnClickedAction()
    {
        MaskClick.Instance.OnClickMask(dialogueController, isDone, true);
    }
}