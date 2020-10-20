using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : Shot
{
    private void Update()
    {
        if (Utilities.IsInsideLevelLimits(transform.position) == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != entity.tag && Utilities.GetEntitiesTags().Contains(collision.transform.tag))
        {
            collision.transform.GetComponent<Entity>().GetHealthSystem().DecreaseHealth(10f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
