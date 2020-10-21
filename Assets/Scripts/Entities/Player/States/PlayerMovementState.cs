using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    private Vector3 axisInput;
    private float movementSpeed = 0.5f;
    private DashMovement dashMovement;

    public PlayerMovementState(Entity entity, MonoBehaviour mono) : base(entity)
    {
        dashMovement = new DashMovement(entity.GetRigidBody());
    }
    public override void Tick()
    {
        if(dashMovement.IsDashing() == false)
        {
            axisInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            dashMovement.DoDash();
        }
    }

    public override void TickFixedUpdate()
    {
        if(dashMovement.IsDashing() == false)
        {
            Vector3 direction = axisInput.normalized * movementSpeed * Time.deltaTime;
            if (Utilities.IsInsideLevelLimits(entity.transform.position + direction) == true)
            {
                entity.GetRigidBody().MovePosition(entity.transform.position + direction);
            }
        }
    }
    public override void OnStateEnter()
    {

    }
    public override void OnStateExit()
    {

    }

    public DashMovement GetDashMovement()
    {
        return dashMovement;
    }

    public override void OnCollisionEvent(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyShot"))
        {
            Shot shot = collision.transform.GetComponent<Shot>();
            entity.GetHealthSystem().DecreaseHealth(shot.GetDamage());
            GameObject.Destroy(collision.gameObject);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Entity enemyEntity = collision.gameObject.GetComponent<Entity>();
            if (GetDashMovement().IsDashing() == true)
            {
                HealthSystem healthSystem = enemyEntity.GetHealthSystem();
                healthSystem.DecreaseHealth(healthSystem.GetHealthAmount());
            }
        }
    }
}
