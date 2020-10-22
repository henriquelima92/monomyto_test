using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeElement : Entity
{
    public Action<PlayerShotSystem> OnRechargeEvent;

    [SerializeField]
    private ShotType shotTypeToRecharge;
    [SerializeField]
    private int shotAmountToRecharge = 10;
    [SerializeField]
    private ParticleSystem deathParticleSystem;

    private ExplosionEffect explosionEffect;

    public override void EntityDefeat()
    {
        explosionEffect.Play();
        PointsFeedback.OnEventOcurred?.Invoke(winPoints.ToString(), transform.position);
        PointsManager.OnPointUpdate?.Invoke(winPoints);

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
        SetState(new RechargeElementMovement(this, shotTypeToRecharge, shotAmountToRecharge));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEvent(collision);
    }
}
