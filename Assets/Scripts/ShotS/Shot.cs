using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shot : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected Entity entity;
    [SerializeField]
    protected float movementSpeed;
    [SerializeField]
    protected Vector3 direction;

    public void Setup(Vector3 direction, float movementSpeed, Entity emitter)
    {
        this.direction = direction;
        this.movementSpeed = movementSpeed;
        entity = emitter;

        SetToEntityLayer();
        ShotInDirection(direction);
    }
    private void ShotInDirection(Vector3 direction)
    {
        rb.AddForce(direction * movementSpeed);
    }

    private void SetToEntityLayer()
    {
        gameObject.layer = entity.gameObject.layer;
    }
}
