using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public static Action OnStartTimerEnd;
    public static LevelBuilder builder;

    [SerializeField]
    private LevelData levelData;

    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject normalRecharge;
    [SerializeField]
    private GameObject doubleRecharge;
    [SerializeField]
    private GameObject scareRecharge;
    [SerializeField]
    private GameObject frozenRecharge;
    [SerializeField]
    private GameObject playerCharacter;

    private void Start()
    {
        builder = this;
        OnStartTimerEnd += Build;
    }

    private void OnDestroy()
    {
        OnStartTimerEnd -= Build;
    }

    private void Build()
    {
        Instantiate(playerCharacter, new Vector3(0f, 0f, 0f), Quaternion.identity);
        InstantiateGroupInRandomPosition(enemy, levelData.EnemiesNumber);
        InstantiateGroupInRandomPosition(normalRecharge, levelData.Normal);
        InstantiateGroupInRandomPosition(doubleRecharge, levelData.Double);
        InstantiateGroupInRandomPosition(scareRecharge, levelData.Scare);
        InstantiateGroupInRandomPosition(frozenRecharge, levelData.Frozen);
    }

    private void InstantiateGroupInRandomPosition(GameObject prefab, int count)
    {
        for (int i = 0; i <count; i++)
        {
            Instantiate(
                prefab,
                new Vector2(GetExcludedRangePosition(levelData.MinWidth, levelData.MaxWidth, levelData.EnemiesStartingDistance),
                            GetExcludedRangePosition(levelData.MinHeight, levelData.MaxHeight, levelData.EnemiesStartingDistance)),
                Quaternion.identity);
        }
    }

    private float GetExcludedRangePosition(float min, float max, float distanceFromPlayer)
    {
        float minValue = UnityEngine.Random.Range(min, distanceFromPlayer);
        float maxValue = UnityEngine.Random.Range(distanceFromPlayer, max);

        float resolution = UnityEngine.Random.Range(0, 100) >= 50 ? maxValue : minValue;
        return resolution;
    }

    public KeyCode GetDashKeyCode()
    {
        return levelData.DashMovement;
    }
    public KeyCode GetShotKeyCode()
    {
        return levelData.Shot;
    }
    public KeyCode GetWeaponKeyCode()
    {
        return levelData.ChangeWeapon;
    }
}
