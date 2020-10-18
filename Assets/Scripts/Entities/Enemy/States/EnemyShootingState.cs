using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingState : State
{
    private Transform target;

    public EnemyShootingState(Entity entity, Transform target) : base(entity)
    {
        this.target = target;
    }
    public override void Tick() 
    {
        if(HasPlayerInSight() == true)
        {
            //shot
        }
        else
        {
            entity.SetState(new EnemyChaseState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    public override void OnStateExit() { }

    private bool HasPlayerInSight()
    {
        if (Vector2.Distance(entity.transform.position, target.position) < 2f)
            return true;

        return false;
    }
}
