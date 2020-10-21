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
        entity.GetRigidBody().MovePosition(entity.transform.position + (targetDirection*-1) * movementSpeed * Time.deltaTime);
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
}
