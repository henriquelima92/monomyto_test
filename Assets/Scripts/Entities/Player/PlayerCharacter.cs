using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Entity
{
    [SerializeField]
    private List<GameObject> shotPrefabs;
    [SerializeField]
    private ShotSystem shotSystem;

    private void Start()
    {
        shotSystem = new ShotSystem(this, shotPrefabs);
        SetState(new PlayerMovementState(this));
    }
    private void Update()
    {
        currentState.Tick();
        shotSystem.Tick();
    }
}
