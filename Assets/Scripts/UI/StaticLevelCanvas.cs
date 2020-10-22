using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StaticLevelCanvas : MonoBehaviour
{
    public static Action OnLevelStart;
    public static Action OnLevelEnd;

    [SerializeField]
    private GameObject edgePanel;
    [SerializeField]
    private GameObject middlePanel;

    [SerializeField]
    private Texture2D cursorTexture;
    [SerializeField]
    private Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        OnLevelEnd += LevelEnd;
        OnLevelStart += LevelStart;
    }

    private void OnDestroy()
    {
        OnLevelEnd -= LevelEnd;
        OnLevelStart -= LevelStart;
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

    private void LevelStart()
    {
        edgePanel.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
    }

    private void LevelEnd()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        StartCoroutine(Utilities.CallMethodWithDelay(() => 
        {
            edgePanel.SetActive(false);
            middlePanel.SetActive(true);
        }, 2));
    }
}
