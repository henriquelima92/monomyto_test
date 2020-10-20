using System;
using UnityEngine;

[Serializable]
public abstract class Entity : MonoBehaviour
{
    public Action OnEntityDefeat;
    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    protected State currentState;
    [SerializeField]
    protected float health = 100f;
    [SerializeField]
    protected HealthSystem healthSystem;
    [SerializeField]
    protected ShotSystem shotSystem;


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
        return healthSystem != null ? healthSystem : null;
    }
    public ShotSystem GetShotSystem()
    {
        return shotSystem != null ? shotSystem : null;
    }
    public Rigidbody2D GetRigidBody()
    {
        return rb;
    }
}
