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
        rb = GetComponent<Rigidbody2D>();

        healthSystem = new HealthSystem(this, startHealth);
        shotSystem = new PlayerShotSystem(this, shotPrefabs);

        OnEntityDefeat += EntityDefeat;
    }
    private void Start()
    {
        SetState(new PlayerMovementState(this, this.GetComponent<MonoBehaviour>()));
    }
    private void Update()
    {
        currentState.Tick();
        shotSystem.Tick();
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            healthSystem.DecreaseHealth(shot.GetDamage());
            Destroy(collision.gameObject);
        }
    }
}
