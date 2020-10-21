using System;
using UnityEngine;

[Serializable]
public abstract class State
{
    protected Entity entity;

    protected State(Entity entity)
    {
        this.entity = entity;
    }
    public abstract void Tick();
    public virtual void OnCollisionEvent(Collision2D collision) { }
    public virtual void TickFixedUpdate() {}

    public virtual void OnStateEnter() {}
    public virtual void OnStateExit() {}
}
