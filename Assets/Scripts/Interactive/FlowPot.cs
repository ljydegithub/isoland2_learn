using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FlowPot : Interactive
{
    public Transform key;

    private Vector3 point;

    private void Start()
    {
        point = transform.position;
        point.x -= 10;
        key.gameObject.SetActive(false);
        if (isDone)
            transform.localPosition = point;
    }

    public override void EmptyClicked()
    {
        if (!isDone)
        {
            isDone = !isDone;
            GetComponent<BoxCollider2D>().enabled = false;
            key.gameObject.SetActive(true);
            transform.DOLocalMove(point, 0.1f).SetLoops(1, LoopType.Incremental);
     
            key.transform.DOLocalJump(point, 3, 1, 1);
            base.SetState();
        }
    }
}