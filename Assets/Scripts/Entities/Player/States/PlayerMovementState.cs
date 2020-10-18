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
        if (Utilities.IsInsideLevelLimits(entity.transform.position + axisInput * movementSpeed * Time.deltaTime) == true)
        {
            entity.transform.position += (axisInput * movementSpeed * Time.deltaTime);
        }
    }

    public override void OnStateEnter()
    {

    }
    public override void OnStateExit()
    {

    }
}
