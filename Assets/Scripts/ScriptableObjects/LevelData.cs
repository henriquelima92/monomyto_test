using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "LevelData/Create", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("Level Limits")]
    [Range(-20.0f, 3f)]
    public float MinWidth = -20f;
    [Range(3f, 20.0f)]
    public float MaxWidth = 0f;
    [Range(-20.0f, 3f)]
    public float MinHeight = -20f;
    [Range(3f, 20.0f)]
    public float MaxHeight = 0f;

    [Tooltip("Starting distance from player to enemies, should be higher than 2.5f to avoid instant shooting")]
    [Range(3f, 10.0f)]
    public float EnemiesStartingDistance = 3f;

    [Header("Enemies")]
    public int EnemiesNumber;
    
    [Header("Recharge Boxes")]
    public int Normal;
    public int Double;
    public int Scare;
    public int Frozen;

    [Header("Keyboard/Mouse buttons")]
    public KeyCode DashMovement;
    public KeyCode Shot;
    public KeyCode ChangeWeapon;
}
