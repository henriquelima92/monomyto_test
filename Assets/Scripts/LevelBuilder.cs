using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
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

    private void Start()
    {
        builder = this;

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
        float minValue = Random.Range(min, distanceFromPlayer);
        float maxValue = Random.Range(distanceFromPlayer, max);

        float resolution = Random.Range(0, 100) >= 50 ? maxValue : minValue;
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
