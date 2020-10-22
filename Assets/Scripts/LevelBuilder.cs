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

    

    private float minPlayerDistance = -3f;
    private float maxPlayerDistance = 3f;

    private void Start()
    {
        builder = this;
        OnStartTimerEnd += Build;
    }

    private void OnDestroy()
    {
        OnStartTimerEnd -= Build;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Build()
    {
        Instantiate(playerCharacter, new Vector3(0f, 0f, 0f), Quaternion.identity);
        InstantiateGroupInRandomPosition(enemy, levelData.EnemiesNumber, false);

        InstantiateGroupInRandomPosition(normalRecharge, levelData.Normal, true);
        InstantiateGroupInRandomPosition(doubleRecharge, levelData.Double, true);
        InstantiateGroupInRandomPosition(scareRecharge, levelData.Scare, true);
        InstantiateGroupInRandomPosition(frozenRecharge, levelData.Frozen, true);
    }

    private void InstantiateGroupInRandomPosition(GameObject prefab, int count, bool ignoreMinPosition)
    {
        for (int i = 0; i <count; i++)
        {
            Vector2 position = Vector2.zero;
            if (ignoreMinPosition == false)
            {
                position = new Vector2(
                GetRandomPostionWithMinDistance(levelData.MinWidth, levelData.MaxWidth),
                GetRandomPostionWithMinDistance(levelData.MinHeight, levelData.MaxHeight));
            }
            else
            {
                position = new Vector2(
                    GetRandomPostion(levelData.MinWidth, levelData.MaxWidth),
                    GetRandomPostion(levelData.MinHeight, levelData.MaxHeight));
            }
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    private float GetRandomPostionWithMinDistance(float min, float max)
    {
        float minValue = UnityEngine.Random.Range(min, minPlayerDistance);
        float maxValue = UnityEngine.Random.Range(maxPlayerDistance, max);

        float resolution = UnityEngine.Random.Range(0, 100) >= 50 ? maxValue : minValue;
        
        return resolution;
    }

    private float GetRandomPostion(float min, float max)
    {
        float position = UnityEngine.Random.Range(min, max);
        return position;
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

    public int GetNormalStartAmmo()
    {
        return levelData.NormalStartAmmo;
    }
    public int GetDoubleStartAmmo()
    {
        return levelData.DoubleStartAmmo;
    }
    public int GetScareStartAmmo()
    {
        return levelData.ScareStartAmmo;
    }
    public int GetFrozenStartAmmo()
    {
        return levelData.FrozenStartAmmo;
    }
    
    public Vector2 GetWidth()
    {
        return new Vector2(levelData.MinWidth, levelData.MaxWidth);
    }
    public Vector2 GetHeight()
    {
        return new Vector2(levelData.MinHeight, levelData.MaxHeight);
    }

    public bool IsInsideLevelLimits(Vector2 position)
    {
        if (position.x < levelData.MaxWidth && position.x > levelData.MinWidth
            && position.y < levelData.MaxHeight && position.y > levelData.MinHeight)
        {
            return true;
        }

        return false;
    }
    public Vector2 GetRandomPointInLevel()
    {
        return new Vector2(
            UnityEngine.Random.Range(levelData.MinWidth, levelData.MaxWidth),
            UnityEngine.Random.Range(levelData.MinHeight, levelData.MaxHeight));
    }
}
