using System.Collections;
using UnityEngine;

public class DashMovement
{
    private Rigidbody2D entityRigidBody;
    private MonoBehaviour entityMonoBehaviour;

    private bool isDashing = false;
    private float dashLength;
    private float dashSpeed = 2.5f;

    public DashMovement(Rigidbody2D entityRigidBody, float dashSpeed = 2.5f, float dashLength = 0.2f)
    {
        this.entityRigidBody = entityRigidBody;
        this.dashSpeed = dashSpeed;
        this.dashLength = dashLength;
        entityMonoBehaviour = entityRigidBody.gameObject.GetComponent<MonoBehaviour>();
    }

    public bool IsDashing()
    {
        return isDashing;
    }
    public void DoDash()
    {
        if(isDashing == false)
        {
            entityMonoBehaviour.StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        Vector3 direction = Utilities.GetMousePositionDirection(entityRigidBody.transform.position);

        float currentDashTime = 0f;
        isDashing = true;

        while (currentDashTime < dashLength)
        {
            currentDashTime += Time.deltaTime;
            if (Utilities.IsInsideLevelLimits(entityRigidBody.transform.position + direction) == true)
            {
                entityRigidBody.velocity = direction * dashSpeed;
            }
            yield return null;
        }
        entityRigidBody.velocity = Vector3.zero;
        isDashing = false;
    }


}
