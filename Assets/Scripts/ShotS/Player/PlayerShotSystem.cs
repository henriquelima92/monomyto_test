using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerShotSystem : ShotSystem
{
    [SerializeField]
    private List<int> shotsAmount;
    [SerializeField]
    private int shotSelected;

    public PlayerShotSystem(Entity entity, List<GameObject> shotPrefabs) : base(entity, shotPrefabs)
    {
        shotSelected = 0;
        shotsAmount = new List<int> {10,10,10};
    }

    public override void Tick()
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

    public override void CreateShot()
    {
        if(shotsAmount[shotSelected] > 0)
        {
            shotsAmount[shotSelected] -= 1;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (new Vector3(mousePosition.x, mousePosition.y, 0f) - entity.transform.position).normalized;
            
            GameObject shotObject = GameObject.Instantiate(prefabs[shotSelected], entity.transform.position, Quaternion.identity);
            Shot shot = shotObject.GetComponent<Shot>();
            shot.Setup(direction, 10, entity);

            Debug.Log("shoot with shot index: " + shotSelected);
            Debug.Log("shots left: " + shotsAmount[shotSelected]);
        }
        else
        {
            Debug.Log("out of shots with index: " + shotSelected);
        }
    }
    private void ChangeShotType()
    {
        shotSelected = (shotSelected < shotsAmount.Count - 1) ? (shotSelected += 1) : 0;
        Debug.Log("change to shot index: " + shotSelected);
    }
}
