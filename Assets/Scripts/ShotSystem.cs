using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShotSystem
{
    private Entity entity;
    [SerializeField]
    private List<GameObject> prefabs;
    [SerializeField]
    private List<int> shotsAmount;
    [SerializeField]
    private int shotSelected;

    public ShotSystem(Entity entity, List<GameObject> shotPrefabs)
    {
        this.entity = entity;
        prefabs = shotPrefabs;
        shotSelected = 0;
        shotsAmount = new List<int> {10,10,10};
    }

    public void Tick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateShot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeShotType();
        }
    }

    private void ChangeShotType()
    {
        shotSelected = (shotSelected < shotsAmount.Count-1) ? (shotSelected += 1) : 0;
        Debug.Log("change to shot index: " + shotSelected);
    }

    private void CreateShot()
    {
        if(shotsAmount[shotSelected] > 0)
        {
            shotsAmount[shotSelected] -= 1;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);
            Vector3 direction = (mousePosition - entity.transform.position).normalized;
            
            GameObject shotObject = GameObject.Instantiate(prefabs[shotSelected], entity.transform.position, Quaternion.identity);
            Shot shot = shotObject.GetComponent<Shot>();
            shot.SetDirection(direction);


            Debug.Log("shoot with shot index: " + shotSelected);
            Debug.Log("shots left: " + shotsAmount[shotSelected]);
        }
        else
        {
            Debug.Log("out of shots with index: " + shotSelected);
        }
    }
}
