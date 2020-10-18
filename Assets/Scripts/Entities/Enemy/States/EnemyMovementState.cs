using System;
using UnityEngine;

[Serializable]
public class EnemyMovementState : State
{
    [SerializeField]
    private float movementSpeed = 0.5f;
    [SerializeField]
    private Vector2 nextDestination;

    public EnemyMovementState(Entity entity) : base(entity) { }
    public override void Tick() 
    { 
        if(ReachedDestination() == true)
        {
            nextDestination = GetRandomDestination();
        }

        entity.transform.position = Vector2.MoveTowards(entity.transform.position, nextDestination, movementSpeed * Time.deltaTime);
        
    }
    public override void OnStateEnter() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.yellow;
        nextDestination = GetRandomDestination();
    }
    public override void OnStateExit() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.white;
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
