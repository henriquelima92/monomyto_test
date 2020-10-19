using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shot : MonoBehaviour
{
    [SerializeField]
    protected Entity entity;
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected Vector3 direction;

    public void Setup(Vector3 direction, Entity emitter)
    {
        this.direction = new Vector3(direction.x, direction.y, 0f);
        entity = emitter;
    }
}
