using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Entity
{
    private ShotSystem shotSystem;

    private void Start()
    {
        shotSystem = new ShotSystem();
        SetState(new PlayerMovementState(this));
    }
    private void Update()
    {
        currentState.Tick();
        shotSystem.Tick();
    }
}
