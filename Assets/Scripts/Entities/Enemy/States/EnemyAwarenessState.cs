using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarenessState : State
{
    private Vector3 targetDirection;
    private float movementSpeed = 0.5f;
    public EnemyAwarenessState(Entity entity, Transform target) : base(entity) 
    {
        this.target = target;
    }

    public override void TickFixedUpdate()
    {
        if (target == null) return;

        entity.GetRigidBody().MovePosition(entity.transform.position + (targetDirection*-1) * movementSpeed * Time.deltaTime);
    }
    public override void Tick()
    {
        if (target == null) return; 
        ;
        if (HasEscaped() == true)
        {
            entity.SetState(new EnemyMovementState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.red;
        targetDirection = (target.transform.position - entity.transform.position).normalized;
    }
    public override void OnStateExit()
    {
        entity.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private bool HasEscaped()
    {
        if (Vector2.Distance(entity.transform.position, target.position) > 5f)
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
                case ShotType.Frozen:
                    entity.SetState(new EnemyFrozenState(entity, target));
                    break;
            }
            GameObject.Destroy(shot.gameObject);
        }
    }
}
