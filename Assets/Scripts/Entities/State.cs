using System;
using UnityEngine;

[Serializable]
public abstract class State
{
    protected Transform target;
    protected Entity entity;

    protected State(Entity entity)
    {
        this.entity = entity;
    }
    public virtual void Tick() {}
    public virtual void OnCollisionEvent(Collision2D collision) { }
    public virtual void TickFixedUpdate() {}

    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}
}
