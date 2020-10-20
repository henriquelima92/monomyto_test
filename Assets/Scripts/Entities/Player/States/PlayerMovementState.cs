using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    private Vector3 axisInput;
    private float movementSpeed = 0.5f;

    public PlayerMovementState(Entity entity) : base(entity)
    {
        
    }
    public override void Tick()
    {
        axisInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public override void TickFixedUpdate()
    {
        Vector3 direction = axisInput.normalized * movementSpeed * Time.deltaTime;
        if (Utilities.IsInsideLevelLimits(entity.transform.position + direction) == true)
        {
            entity.GetRigidBody().MovePosition(entity.transform.position + direction);
        }
    }

    public override void OnStateEnter()
    {

    }
    public override void OnStateExit()
    {

    }
}
