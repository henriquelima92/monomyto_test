using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI StartingTimer;
    [SerializeField]
    private float currentTimer;

    private void Start()
    {
        currentTimer = 5f;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            LevelBuilder.OnStartTimerEnd?.Invoke();
            StaticLevelCanvas.OnLevelStart.Invoke();
            gameObject.SetActive(false);
        }
        else
        {
            StartingTimer.text = Mathf.RoundToInt(currentTimer).ToString();
        }
    }
}
