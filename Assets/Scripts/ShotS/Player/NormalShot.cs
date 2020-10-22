using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : Shot
{
    private void Update()
    {
        if (LevelBuilder.builder.IsInsideLevelLimits(transform.position) == false)
        {
            Destroy(gameObject);
        }
    }
}
