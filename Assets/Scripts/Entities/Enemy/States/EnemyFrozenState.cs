using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFrozenState : State
{
    private Transform target;
    private float frozenTime = 3.5f;
    public EnemyFrozenState(Entity entity, Transform target) : base(entity)
    {
        this.target = target;
    }

    public override void Tick()
    {
        frozenTime -= Time.deltaTime;
        if(frozenTime < 0)
        {
            entity.SetState(new EnemyMovementState(entity, target));
        }
    }
    public override void OnStateEnter()
    {
        entity.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public override void OnStateExit() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void OnCollisionEvent(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            entity.GetHealthSystem().DecreaseHealth(shot.GetDamage());
            GameObject.Destroy(shot.gameObject);
        }
    }
}
