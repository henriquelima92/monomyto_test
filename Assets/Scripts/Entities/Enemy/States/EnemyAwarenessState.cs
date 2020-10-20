using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwarenessState : State
{
    private Transform target;
    private Vector3 targetDirection;
    private float movementSpeed = 0.5f;
    public EnemyAwarenessState(Entity entity, Transform target) : base(entity) 
    {
        this.target = target;
    }

    public override void TickFixedUpdate()
    {
        Vector3 direction = (target.transform.position - entity.transform.position).normalized;
        entity.GetRigidBody().MovePosition(entity.transform.position + targetDirection * movementSpeed * Time.deltaTime);
    }
    public override void Tick()
    {
        if(HasEscaped() == true)
        {
            entity.SetState(new EnemyMovementState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        targetDirection = (target.transform.position * -1 - entity.transform.position).normalized;
        entity.GetComponent<SpriteRenderer>().color = Color.magenta;
    }
    public override void OnStateExit() { }

    private bool HasEscaped()
    {
        if (Vector2.Distance(entity.transform.position, target.position) > 5f)
            return true;

        return false;
    }
}
