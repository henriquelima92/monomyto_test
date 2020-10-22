using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities 
{
    public const string ENEMYTAG = "EnemyEntity";
    public const string PLAYERTAG = "PlayerEntity";
    public const string BOXTAG = "BoxEntity";

    public static Vector3 GetMousePositionDirection(Vector3 from)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (new Vector3(mousePosition.x, mousePosition.y, 0f) - from).normalized;
        return direction;
    }

    //public static Vector2 GetRandomPointInLevel()
    //{
    //    return new Vector2(
    //        UnityEngine.Random.Range(MINLEVELWIDTH, MAXLEVELWIDTH),
    //        UnityEngine.Random.Range(MINLEVELHEIGHT, MAXLEVELHEIGHT));
    //}

    public static IEnumerator DisableObjectAfterTime(GameObject gameobject, float time)
    {
        yield return new WaitForSeconds(time);
        gameobject.SetActive(false);
    }

    public static IEnumerator CallMethodWithDelay(Action method, float time)
    {
        yield return new WaitForSeconds(time);
        method();
    }
}
