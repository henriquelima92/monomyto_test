using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "LevelLimits/Create", order = 1)]
public class LevelLimits : ScriptableObject
{
    public float MinWidth;
    public float MaxWidth;
    public float MinHeight;
    public float MaxHeight;
}
