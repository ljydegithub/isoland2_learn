using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GuideManager : Singleton<GuideManager>
{

    // public BoxCollider2D boxCollider2D;
    // private void Start()
    // {
    //     boxCollider2D.enabled = false;
    //     Animator animator = GetComponent<Animator>();
    //     StartCoroutine(YieldAniFinish(animator, "GuideAnimation", () =>
    //     {
    //         Debug.Log(animator.name);
    //         boxCollider2D.enabled = true;
    //     }));
    // }
    //
    // public static IEnumerator YieldAniFinish(Animator ani,string aniName, Action action)
    // {   
    //     yield return null;
    //     AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
    //     if (stateInfo.IsName(aniName) && (stateInfo.normalizedTime > 1.0f))
    //         action();
    //     else
    //         Instance.StartCoroutine(YieldAniFinish(ani,aniName, action));
    // }
}