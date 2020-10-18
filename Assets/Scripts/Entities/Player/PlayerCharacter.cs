using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Entity
{
    private void Start()
    {
        SetState(new PlayerMovementState(this));
    }
    private void Update()
    {
        currentState.Tick();
    }
}
