using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PointsFeedback : MonoBehaviour
{
    public static Action<string, Vector3> OnEventOcurred;
    [SerializeField]
    private List<TextMeshProUGUI> points;

    private void Awake()
    {
        OnEventOcurred += SetAvailablePoint;
    }

    private void OnDestroy()
    {
        OnEventOcurred -= SetAvailablePoint;
    }

    public void SetAvailablePoint(string text, Vector3 position)
    {
        for (int i = 0; i < points.Count; i++)
        {
            if(points[i].gameObject.activeInHierarchy == false)
            {
                points[i].transform.position = position;
                points[i].text = $"+{text}";
                points[i].gameObject.SetActive(true);
                float animationLength = points[i].GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length;
                StartCoroutine(Utilities.DisableObjectAfterTime(points[i].gameObject, animationLength));
                return;
            }
        }
    }
}
