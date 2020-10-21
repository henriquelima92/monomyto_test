using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingState : State
{
    private ShotSystem shotSystem;

    public EnemyShootingState(Entity entity, Transform target) : base(entity)
    {
        this.target = target;
    }
    public override void Tick() 
    {
        if (target == null) return;

        if (HasPlayerInSight() == true)
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

    public override void OnCollisionEvent(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            entity.GetHealthSystem().DecreaseHealth(shot.GetDamage());
            switch (shot.GetShotType())
            {
                case ShotType.Normal:
                case ShotType.Double:
                    if (entity.GetHealthSystem().GetHealthAmount() <= (entity.GetStartHealth() / 3))
                    {
                        entity.SetState(new EnemyAwarenessState(entity, target));
                    }
                    break;
                case ShotType.Scare:
                    entity.SetState(new EnemyAwarenessState(entity, target));
                    break;
                case ShotType.Frozen:
                    entity.SetState(new EnemyFrozenState(entity, target));
                    break;
            }
            GameObject.Destroy(shot.gameObject);
        }
    }
}
