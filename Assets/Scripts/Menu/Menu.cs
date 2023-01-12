using System;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // private void Start()
    // {
    //     StartCoroutine(GameStart());
    // }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        // 加载游戏进度
        SaveLoadManager.Instance.Load();
    }

    public void GoBackToMenu()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        TransitionManager.Instance.Transition(currentScene, SceneName.Menu.ToString());
        // 保存游戏进度
        SaveLoadManager.Instance.Save();
    }
    
    public void StartGameWeek(int gameWeek)
    {
        EventHandler.CallStartNewGameEvent(gameWeek);
    }

    // public IEnumerator GameStart()
    // {
    //     yield return new WaitForSeconds(2);
    //     EventHandler.CallStartNewGameEvent(0);
    // }
}
