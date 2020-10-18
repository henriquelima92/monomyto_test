using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : State
{
    private Transform target;
    private float movementSpeed = 0.5f;
    private float chaseTime = 5f;
    private float currentChaseTime = 0f;

    public EnemyChaseState(Entity entity, Transform target) : base(entity) 
    {
        this.target = target;
    }
    public override void Tick() 
    {
        currentChaseTime += Time.deltaTime;
        if(currentChaseTime < chaseTime)
        {
            entity.transform.position = Vector2.MoveTowards(entity.transform.position, target.transform.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            entity.SetState(new EnemyMovementState(entity, target));
        }
    }
    public override void OnStateEnter() 
    {
        entity.GetComponent<SpriteRenderer>().color = Color.green;
    }
    public override void OnStateExit() { }
}
