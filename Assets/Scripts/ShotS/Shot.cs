using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shot : MonoBehaviour
{
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected Vector3 direction;

    public void SetDirection(Vector3 direction)
    {
        this.direction = new Vector3(direction.x, direction.y, 0f);
    }

    public bool IsInLevelLimits()
    {
        return Utilities.IsInsideLevelLimits(transform.position);
    }
}
