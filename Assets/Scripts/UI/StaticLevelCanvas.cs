using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StaticLevelCanvas : MonoBehaviour
{
    public static Action OnLevelEnd;

    [SerializeField]
    private GameObject edgePanel;
    [SerializeField]
    private GameObject middlePanel;

    private void Awake()
    {
        OnLevelEnd += LevelEnd;
    }

    private void OnDestroy()
    {
        OnLevelEnd -= LevelEnd;
    }

    public void PlayAgain()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

    private void LevelEnd()
    {
        edgePanel.SetActive(false);
        middlePanel.SetActive(true);
    }
}
