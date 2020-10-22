using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "LevelData/Create", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("Level Limits")]
    [Range(-3, -20)]
    public int MinWidth = -3;
    [Range(3, 20)]
    public int MaxWidth = 3;
    [Range(-3, -20)]
    public int MinHeight = -3;
    [Range(3, 20)]
    public int MaxHeight = 3;

    [Header("Enemies")]
    public int EnemiesNumber;
    
    [Header("Recharge Boxes")]
    public int Normal;
    public int Double;
    public int Scare;
    public int Frozen;

    [Header("Player")]
    public int NormalStartAmmo;
    public int DoubleStartAmmo;
    public int ScareStartAmmo;
    public int FrozenStartAmmo;

    [Header("Keyboard/Mouse buttons")]
    public KeyCode DashMovement;
    public KeyCode Shot;
    public KeyCode ChangeWeapon;
}
