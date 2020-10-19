using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : Shot
{
    private void Start()
    {
        movementSpeed = 10f;
    }
    private void Update()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
        if(Utilities.IsInsideLevelLimits(transform.position) == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != entity.tag && Utilities.GetEntitiesTags().Contains(collision.tag))
        {
            Debug.Log(collision.transform.tag);
            collision.GetComponent<Entity>().GetHealthSystem().DecreaseHealth(10f);
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
