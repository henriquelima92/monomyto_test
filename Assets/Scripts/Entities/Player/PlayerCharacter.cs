using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Entity
{
    [SerializeField]
    private List<GameObject> shotPrefabs;

    public override void EntityDefeat()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        healthSystem = new HealthSystem(this, health);
        shotSystem = new PlayerShotSystem(this, shotPrefabs);

        OnEntityDefeat += EntityDefeat;
    }
    private void Start()
    {
        SetState(new PlayerMovementState(this));
    }
    private void Update()
    {
        currentState.Tick();
        shotSystem.Tick();
    }
    private void OnDestroy()
    {
        OnEntityDefeat -= EntityDefeat;
    }
}
