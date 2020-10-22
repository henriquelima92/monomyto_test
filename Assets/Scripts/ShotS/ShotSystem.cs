using System.Collections.Generic;
using UnityEngine;

public abstract class ShotSystem
{
    protected Entity entity;
    protected List<GameObject> prefabs;

    protected ShotSystem(Entity entity, List<GameObject> prefabs)
    {
        this.entity = entity;
        this.prefabs = prefabs;
    }
    public abstract void Tick();
    public abstract void CreateShot();

    public virtual void ResetSystem() {}
}
