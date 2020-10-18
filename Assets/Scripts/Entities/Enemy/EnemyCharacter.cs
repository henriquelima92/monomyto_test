using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Entity
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindWithTag("PlayerEntity").transform;
        SetState(new EnemyMovementState(this, target));   
    }
    private void Update()
    {
        currentState.Tick();
    }
}
