using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Entity
{
    private Transform target;

    public override void EntityDefeat()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        healthSystem = new HealthSystem(this, health);

        OnEntityDefeat += EntityDefeat;
    }

    private void Start()
    {
        target = GameObject.FindWithTag("PlayerEntity").transform;
        SetState(new EnemyMovementState(this, target));   
    }
    private void Update()
    {
        currentState.Tick();
    }

    private void OnDestroy()
    {
        OnEntityDefeat -= EntityDefeat;
    }
}
