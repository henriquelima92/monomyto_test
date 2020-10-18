using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Entity
{
    private void Start()
    {
        SetState(new EnemyMovementState(this));   
    }
    private void Update()
    {
        currentState.Tick();
    }
}
