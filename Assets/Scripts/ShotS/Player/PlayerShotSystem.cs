using System;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    Normal,
    Double,
    Scare,
    Frozen
}

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
        shotsAmount = new List<int> {10,10,10,10};
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
            Vector3 direction = Utilities.GetMousePositionDirection(entity.transform.position);

            GameObject shotObject = GameObject.Instantiate(prefabs[shotSelected], entity.transform.position, Quaternion.identity);
            Shot shot = shotObject.GetComponent<Shot>();
            shot.Setup(direction, 0.05f, entity, 25f);
        }
        else
        {
            Debug.Log("out of shots with index: " + shotSelected);
        }
    }
    
    public void Recharge(ShotType type, int amount)
    {
        shotsAmount[(int)type] += amount;
    }
    private void ChangeShotType()
    {
        shotSelected = (shotSelected < shotsAmount.Count - 1) ? (shotSelected += 1) : 0;
    }
}
