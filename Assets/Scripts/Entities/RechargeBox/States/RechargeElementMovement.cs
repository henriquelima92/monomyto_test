using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeElementMovement : State
{
    private Vector3 direction;
    private float movementSpeed = 0.01f;

    private ShotType shotTypeToRecharge;
    private int shotAmountToRecharge;
    public RechargeElementMovement(Entity entity, ShotType shotTypeToRecharge, int shotAmountToRecharge) : base(entity)
    {
        this.shotTypeToRecharge = shotTypeToRecharge;
        this.shotAmountToRecharge = shotAmountToRecharge;
    }

    public override void TickFixedUpdate()
    {
        entity.GetRigidBody().MovePosition(entity.transform.position + direction * movementSpeed * Time.deltaTime);
    }
    public override void Tick() { }
    public override void OnStateEnter()
    {
        direction = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0).normalized;
    }
    public override void OnStateExit() { }

    public override void OnCollisionEvent(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerShot"))
        {
            HealthSystem healthSystem = entity.GetHealthSystem();
            Shot shot = collision.transform.GetComponent<Shot>();
            healthSystem.DecreaseHealth(entity.GetStartHealth() / 2);
            Recharge(shot.GetEmitterEntity(), healthSystem);
            GameObject.Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Entity entity = collision.gameObject.GetComponent<Entity>();
            PlayerMovementState playerMovementState = (PlayerMovementState)entity.GetState();
            if (playerMovementState.GetDashMovement().IsDashing() == true)
            {
                HealthSystem healthSystem = entity.GetHealthSystem();
                healthSystem.DecreaseHealth(healthSystem.GetHealthAmount());
                Recharge(entity,healthSystem);
            }
        }
    }
    private void Recharge(Entity entity, HealthSystem healthSystem)
    {
        if(healthSystem.GetHealthAmount() <= 0)
        {
            PlayerShotSystem playerShotSystem = (PlayerShotSystem)entity.GetShotSystem();
            playerShotSystem.Recharge(shotTypeToRecharge, shotAmountToRecharge);
        }
    }
}
