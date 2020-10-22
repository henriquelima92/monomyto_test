using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunsFeedback : MonoBehaviour
{
    public static Action<string, string> OnGunEvent;

    [SerializeField]
    private TextMeshProUGUI gunFeedback;

    private void Awake()
    {
        OnGunEvent += ChangeGunName;
    }

    private void OnDestroy()
    {
        OnGunEvent -= ChangeGunName;
    }

    private void ChangeGunName(string text, string bullets)
    {
        string shots = bullets == "0" ? "(no bullets)" : $"(bullets: {bullets})";
        gunFeedback.text = $"{text} gun {shots}";
    }
}
