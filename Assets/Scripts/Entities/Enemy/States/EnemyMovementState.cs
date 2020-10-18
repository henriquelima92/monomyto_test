using System;
using UnityEngine;

[Serializable]
public class EnemyMovementState : State
{
    private Transform target;
    private float movementSpeed = 0.5f;
    private Vector2 nextDestination;

    public EnemyMovementState(Entity entity, Transform target) : base(entity) 
    {
        this.target = target;
    }
    public override void Tick() 
    { 
        if(ReachedDestination() == true)
        {
            nextDestination = GetRandomDestination();
        }

        entity.transform.position = Vector2.MoveTowards(entity.transform.position, nextDestination, movementSpeed * Time.deltaTime);
        
        if(HasPlayerInSight() == true)
        {
            entity.SetState(new EnemyShootingState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.yellow;
        nextDestination = GetRandomDestination();
    }
    public override void OnStateExit() 
    {
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
}
