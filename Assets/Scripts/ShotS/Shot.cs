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
        this.direction = direction;
    }

    public bool IsInLevelLimits()
    {
        return Utilities.IsInsideLevelLimits(transform.position);
    }
}
