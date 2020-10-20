using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities 
{
    public const float MAXLEVELWIDTH = 7f;
    public const float MINLEVELWIDTH = -7f;
    public const float MAXLEVELHEIGHT = 7f;
    public const float MINLEVELHEIGHT = -7f;

    public const string ENEMYTAG = "EnemyEntity";
    public const string PLAYERTAG = "PlayerEntity";
    public const string BOXTAG = "BoxEntity";

    public static Vector2 GetRandomPointInLevel()
    {
        return new Vector2(
            UnityEngine.Random.Range(MINLEVELWIDTH, MAXLEVELWIDTH),
            UnityEngine.Random.Range(MINLEVELHEIGHT, MAXLEVELHEIGHT));
    }

    public static bool IsInsideLevelLimits(Vector2 position)
    {
        if(position.x < MAXLEVELWIDTH && position.x > MINLEVELWIDTH
            && position.y < MAXLEVELHEIGHT && position.y > MINLEVELHEIGHT)
        {
            return true;
        }

        return false;
    }
}
