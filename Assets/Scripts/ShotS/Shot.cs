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
    [SerializeField]
    protected float damage;

    public void Setup(Vector3 direction, float movementSpeed, Entity emitter, float damage = 10f)
    {
        this.direction = direction;
        this.movementSpeed = movementSpeed;
        this.damage = damage;
        entity = emitter;


        SetToEntityLayer();
        ShotInDirection(direction);
    }

    public Entity GetEmitterEntity()
    {
        return entity;
    }

    public float GetDamage()
    {
        return damage;
    }

    private void ShotInDirection(Vector3 direction)
    {
        rb.AddForce(direction * movementSpeed);
    }

    private void SetToEntityLayer()
    {
        if(entity.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("PlayerShot");
        }
        else if(entity.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameObject.layer = LayerMask.NameToLayer("EnemyShot");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyShot") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
