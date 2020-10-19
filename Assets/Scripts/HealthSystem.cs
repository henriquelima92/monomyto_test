using System;
using UnityEngine;

[Serializable]
public class HealthSystem
{
    public Action<float> OnHealthChange;

    private Entity entity;
    private float health;

    public HealthSystem(Entity entity, float health)
    {
        this.entity = entity;
        this.health = health;
    }

    public float GetHealthAmount()
    {
        return health;
    }
    public void IncreaseHealth(float amount)
    {
        if(health <= 100)
        {
            health += amount;
            OnHealthChange?.Invoke(health);
        }
    }
    public void DecreaseHealth(float amount)
    {
        if(health > 0)
        {
            health -= amount;
            OnHealthChange?.Invoke(health);
            if(health == 0)
            {
                entity.OnEntityDefeat?.Invoke();
            }
        }
    }
}
