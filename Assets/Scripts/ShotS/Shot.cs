using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    Normal,
    Double,
    Scare,
    Frozen
}

public abstract class Shot : MonoBehaviour
{
    [SerializeField]
    protected ShotType type;
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected Entity entity;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Vector3 direction;
    [SerializeField]
    protected float damage;

    public void Setup(Vector3 direction, Entity emitter)
    {
        this.direction = direction;
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

    public ShotType GetShotType()
    {
        return type;
    }

    private void ShotInDirection(Vector3 direction)
    {
        rb.AddForce(direction * speed);
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
