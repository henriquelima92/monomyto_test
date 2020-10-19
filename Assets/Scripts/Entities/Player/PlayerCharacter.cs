using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Entity
{
    [SerializeField]
    private List<GameObject> shotPrefabs;

    [SerializeField]
    private PlayerShotSystem shotSystem;

    private void Awake()
    {
        healthSystem = new HealthSystem(this, health);
        shotSystem = new PlayerShotSystem(this, shotPrefabs);
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
}
