using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public static Action<int> OnPointUpdate;
    [SerializeField]
    private int currentPoints;
    [SerializeField]
    private TextMeshProUGUI edgeScore;
    [SerializeField]
    private TextMeshProUGUI middleScore;
    

    private void Awake()
    {
        currentPoints = 0;
        OnPointUpdate += UpdatePoints;
    }

    private void OnDestroy()
    {
        OnPointUpdate -= UpdatePoints;
    }

    private void UpdatePoints(int points)
    {
        currentPoints += points;
        edgeScore.text = currentPoints.ToString();
        middleScore.text = currentPoints.ToString();
    }
}
