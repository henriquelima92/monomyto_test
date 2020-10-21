using System;
using UnityEngine;

[Serializable]
public abstract class Entity : MonoBehaviour
{
    public Action OnEntityDefeat;

    [SerializeField]
    protected float startHealth = 100f;
    [SerializeField]
    protected ShotSystem shotSystem;

    protected Rigidbody2D rb;
    protected HealthSystem healthSystem;
    protected State currentState;


    public abstract void EntityDefeat();

    public float GetStartHealth()
    {
        return startHealth;
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
    public State GetState()
    {
        return currentState;
    }
    public void SetState(State newState)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = newState;

        if(currentState != null)
        {
            
            currentState.OnStateEnter();
        }
    }
}
