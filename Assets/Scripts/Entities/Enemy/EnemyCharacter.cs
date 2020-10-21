using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Entity
{
    private Transform target;
    [SerializeField]
    private List<GameObject> shotPrefabs;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private ParticleSystem deathParticleSystem;
    private ExplosionEffect explosionEffect;

    public override void EntityDefeat()
    {
        explosionEffect.Play();
        PointsFeedback.OnEventOcurred?.Invoke("20", transform.position);
        PointsManager.OnPointUpdate?.Invoke(20);
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.FindWithTag(Utilities.PLAYERTAG).transform;
        rb = GetComponent<Rigidbody2D>(); 

        healthSystem = new HealthSystem(this, startHealth);
        shotSystem = new EnemyShotSystem(this, shotPrefabs, target);
        explosionEffect = new ExplosionEffect(deathParticleSystem);

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

    private void FixedUpdate()
    {
        currentState.TickFixedUpdate();
    }

    private void OnDestroy()
    {
        OnEntityDefeat -= EntityDefeat;
    }

    private void ShotHandler(Shot shot)
    {
        healthSystem.DecreaseHealth(shot.GetDamage());
        switch (shot.GetShotType())
        {
            case ShotType.Normal:
            case ShotType.Double:
                if((currentState is EnemyFrozenState) == false && (currentState is EnemyAwarenessState) == false)
                {
                    if (healthSystem.GetHealthAmount() <= (startHealth / 3)) // if the current health is less or equal than 1/3 of the total life, set awareness state
                    {
                        SetState(new EnemyAwarenessState(this, target));
                    }
                    else
                    {
                        if ((currentState is EnemyShootingState) == false) // if enemy was shot and his state is not 'shootingState', set shooting state
                        {
                            SetState(new EnemyChaseState(this, target));
                        }
                    }
                }
            break;
            case ShotType.Scare:
                if((currentState is EnemyAwarenessState) == false)
                {
                    SetState(new EnemyAwarenessState(this, target));
                }
            break;
            case ShotType.Frozen:
                if ((currentState is EnemyFrozenState) == false)
                {
                    SetState(new EnemyFrozenState(this, target));
                }
            break;
        }
        Destroy(shot.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            ShotHandler(shot);
        }
    }
}
