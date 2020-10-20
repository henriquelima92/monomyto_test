using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingState : State
{
    private Transform target;
    private ShotSystem shotSystem;

    public EnemyShootingState(Entity entity, Transform target) : base(entity)
    {
        this.target = target;
    }
    public override void Tick() 
    {
        if(HasPlayerInSight() == true)
        {
            shotSystem.Tick();
        }
        else
        {
            entity.SetState(new EnemyChaseState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        shotSystem = entity.GetShotSystem();
    }
    public override void OnStateExit() 
    {
        shotSystem.ResetSystem();
    }

    private bool HasPlayerInSight()
    {
        if (Vector2.Distance(entity.transform.position, target.position) < 2f)
            return true;

        return false;
    }
}
