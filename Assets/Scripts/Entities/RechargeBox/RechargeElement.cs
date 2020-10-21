﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeElement : Entity
{
    [SerializeField]
    private ShotType shotTypeToRecharge;
    [SerializeField]
    private int shotAmountToRecharge = 10;
    [SerializeField]
    private ParticleSystem deathParticleSystem;

    private ExplosionEffect explosionEffect;
    private PlayerShotSystem playerShotSytem;

    public override void EntityDefeat()
    {
        explosionEffect.Play();
        PointsFeedback.OnEventOcurred?.Invoke("10", transform.position);
        PointsManager.OnPointUpdate?.Invoke(10);

        playerShotSytem.Recharge(shotTypeToRecharge, shotAmountToRecharge);
        Destroy(gameObject);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthSystem = new HealthSystem(this, startHealth);
        explosionEffect = new ExplosionEffect(deathParticleSystem);

        OnEntityDefeat += EntityDefeat;
    }
    private void Start()
    {
        SetState(new RechargeElementMovement(this));
    }
    private void Update()
    {
        currentState.Tick();
    }

    private void FixedUpdate()
    {
        currentState.TickFixedUpdate();
    }
    private void OnDestroy()
    {
        OnEntityDefeat -= EntityDefeat;
    }

    private void GetPlayerShotSystem(Entity entity)
    {
        if(playerShotSytem == null)
        {
            playerShotSytem = (PlayerShotSystem)entity.GetShotSystem();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            GetPlayerShotSystem(shot.GetEmitterEntity());
            healthSystem.DecreaseHealth(startHealth / 2);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Entity entity = collision.gameObject.GetComponent<Entity>();
            PlayerMovementState playerMovementState = (PlayerMovementState)entity.GetState();
            if (playerMovementState.GetDashMovement().IsDashing() == true)
            {
                GetPlayerShotSystem(entity);
                healthSystem.DecreaseHealth(healthSystem.GetHealthAmount());
            }
        }
    }
}
