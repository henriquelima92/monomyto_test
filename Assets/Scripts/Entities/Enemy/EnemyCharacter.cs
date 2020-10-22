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
        PointsFeedback.OnEventOcurred?.Invoke(winPoints.ToString(), transform.position);
        PointsManager.OnPointUpdate?.Invoke(winPoints);
        LevelBuilder.OnEnemyDefeat?.Invoke(gameObject);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEvent(collision);
    }
}
