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
    private float bulletDamage;

    public override void EntityDefeat()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        target = GameObject.FindWithTag(Utilities.PLAYERTAG).transform;
        rb = GetComponent<Rigidbody2D>(); 

        healthSystem = new HealthSystem(this, startHealth);
        shotSystem = new EnemyShotSystem(this, shotPrefabs, target, bulletSpeed, bulletDamage);

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
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            healthSystem.DecreaseHealth(shot.GetDamage());
            Destroy(collision.gameObject);

            if(healthSystem.GetHealthAmount() <= (startHealth/3)) // if the current health is less or equal than 1/3 of the total life, set awareness state
            {
                SetState(new EnemyAwarenessState(this, target));
            }
            else
            {
                if(currentState != new EnemyShootingState(this, target)) // if enemy was shot and his state is not 'shootingState', set shooting state
                {
                    SetState(new EnemyChaseState(this, target));
                }
            }
        }
    }
}
