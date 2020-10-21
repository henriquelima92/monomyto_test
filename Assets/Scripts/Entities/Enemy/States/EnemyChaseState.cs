using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : State
{
    private Transform target;
    private float movementSpeed = 0.25f;
    private float chaseTime = 5f;
    private float currentChaseTime = 0f;

    public EnemyChaseState(Entity entity, Transform target) : base(entity) 
    {
        this.target = target;
    }

    public override void TickFixedUpdate()
    {
        Vector3 direction = (target.transform.position - entity.transform.position).normalized;
        entity.GetRigidBody().MovePosition(entity.transform.position + direction * movementSpeed * Time.deltaTime);
    }
    public override void Tick() 
    {
        if (HasPlayerInSight() == true)
        {
            entity.SetState(new EnemyShootingState(entity, target));
        }

        currentChaseTime += Time.deltaTime;
        if (currentChaseTime > chaseTime)
        {
            entity.SetState(new EnemyMovementState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
    }
    public override void OnStateExit() { }

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
