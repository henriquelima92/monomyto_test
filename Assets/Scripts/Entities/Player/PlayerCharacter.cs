using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Entity
{
    public static Action OnLevelWin;

    [SerializeField]
    private List<GameObject> shotPrefabs;
    [SerializeField]
    private ParticleSystem deathParticleSystem;
    private ExplosionEffect explosionEffect;

    public override void EntityDefeat()
    {
        Camera.main.transform.SetParent(null);
        explosionEffect.Play();

        StaticLevelCanvas.OnLevelEnd?.Invoke();

        Destroy(gameObject);
    }

    private void Awake()
    {
        OnEntityDefeat += EntityDefeat;
        OnLevelWin += LevelWin;
    }
    private void Start()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.position = new Vector3(0f, 0f, -10f);

        rb = GetComponent<Rigidbody2D>();

        healthSystem = new HealthSystem(this, startHealth);
        shotSystem = new PlayerShotSystem(this, shotPrefabs);
        explosionEffect = new ExplosionEffect(deathParticleSystem);

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
        OnLevelWin -= LevelWin;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEvent(collision);
    }

    private void LevelWin()
    {
        Camera.main.transform.SetParent(null);
        this.enabled = false;
    }
}
