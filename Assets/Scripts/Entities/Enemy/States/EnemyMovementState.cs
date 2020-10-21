using System;
using UnityEngine;

[Serializable]
public class EnemyMovementState : State
{
    private float movementSpeed = 0.25f;
    private Vector2 nextDestination;

    public EnemyMovementState(Entity entity, Transform target) : base(entity) 
    {
        this.target = target;
    }
    public override void TickFixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = (nextDestination - new Vector2(entity.transform.position.x, entity.transform.position.y)).normalized;
        entity.GetRigidBody().MovePosition(entity.transform.position + direction * movementSpeed * Time.deltaTime);
    }
    public override void Tick() 
    {
        if (target == null) return;

        if (ReachedDestination() == true)
        {
            nextDestination = GetRandomDestination();
        }

        if(HasPlayerInSight() == true)
        {
            entity.SetState(new EnemyShootingState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        nextDestination = GetRandomDestination();
    }

    private bool HasPlayerInSight()
    {
        if (Vector2.Distance(entity.transform.position, target.position) < 2f)
            return true;

        return false;
    }
    private Vector2 GetRandomDestination()
    {
        return Utilities.GetRandomPointInLevel();
    }
    private bool ReachedDestination()
    {
        return Vector3.Distance(entity.transform.position, nextDestination) < 0.5f;
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
                    if (entity.GetHealthSystem().GetHealthAmount() <= (entity.GetStartHealth()/ 3))
                    {
                        entity.SetState(new EnemyAwarenessState(entity, target));
                    }
                    else
                    {
                        entity.SetState(new EnemyChaseState(entity, target));
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
