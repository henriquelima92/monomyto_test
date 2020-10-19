﻿using System;
using UnityEngine;

[Serializable]
public abstract class Entity : MonoBehaviour
{
    public Action OnEntityDefeat;

    [SerializeField]
    protected State currentState;
    [SerializeField]
    protected float health = 100f;
    [SerializeField]
    protected HealthSystem healthSystem;


    public abstract void EntityDefeat();

    public State GetState()
    {
        return currentState;
    }
    public void SetState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnStateEnter();
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.OnStateEnter();
        }
    }
    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
