using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Entity
{
    private Transform target;
    [SerializeField]
    private List<GameObject> shotPrefabs;

    public override void EntityDefeat()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.FindWithTag("PlayerEntity").transform;
        
        healthSystem = new HealthSystem(this, health);
        shotSystem = new EnemyShotSystem(this, shotPrefabs, target);

        OnEntityDefeat += EntityDefeat;
    }

    private void Start()
    {
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
