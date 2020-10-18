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
        Vector3 newPosition = entity.transform.position + axisInput * movementSpeed * Time.deltaTime;
        if (Utilities.IsInsideLevelLimits(newPosition) == true)
        {
            entity.transform.position += (newPosition);
        }
    }

    public override void OnStateEnter()
    {

    }
    public override void OnStateExit()
    {

    }
}
