using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeElementMovement : State
{
    private Vector3 direction;
    private float movementSpeed = 0.01f;
    public RechargeElementMovement(Entity entity) : base(entity)
    {
    }

    public override void TickFixedUpdate()
    {
        entity.GetRigidBody().MovePosition(entity.transform.position + direction * movementSpeed * Time.deltaTime);
    }
    public override void Tick() 
    {
        // implement the level limit logic
    }
    public override void OnStateEnter()
    {
        direction = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0).normalized;
    }
    public override void OnStateExit() { }
}
