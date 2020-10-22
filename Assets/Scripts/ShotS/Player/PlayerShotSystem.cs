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
        shotsAmount = new List<int> {
            LevelBuilder.builder.GetNormalStartAmmo(),
            LevelBuilder.builder.GetDoubleStartAmmo(),
            LevelBuilder.builder.GetScareStartAmmo(),
            LevelBuilder.builder.GetFrozenStartAmmo()};
        GunsFeedback.OnGunEvent?.Invoke(((ShotType)shotSelected).ToString(), shotsAmount[shotSelected].ToString());
    }

    public override void Tick()
    {
        if(Input.GetKeyDown(LevelBuilder.builder.GetShotKeyCode()))
        {
            CreateShot();
        }

        if (Input.GetKeyDown(LevelBuilder.builder.GetWeaponKeyCode()))
        {
            ChangeShotType();
        }
    }

    public override void CreateShot()
    {
        if(shotsAmount[shotSelected] > 0)
        {
            shotsAmount[shotSelected] -= 1;
            GunsFeedback.OnGunEvent?.Invoke(((ShotType)shotSelected).ToString(), shotsAmount[shotSelected].ToString());
            Vector3 direction = Utilities.GetMousePositionDirection(entity.transform.position);
            GameObject shotObject = GameObject.Instantiate(prefabs[shotSelected], entity.transform.position, Quaternion.identity);
            Shot shot = shotObject.GetComponent<Shot>();
            shot.Setup(direction, entity);
            if (shotSelected == (int)ShotType.Double)
            {
                GameObject doubleshotObject = GameObject.Instantiate(prefabs[shotSelected], entity.transform.position, Quaternion.identity);
                Shot doubleshot = doubleshotObject.GetComponent<Shot>();
                doubleshot.Setup(direction * -1, entity);
            }
        }
    }
    
    public void Recharge(ShotType type, int amount)
    {
        shotsAmount[(int)type] += amount;
        GunsFeedback.OnGunEvent?.Invoke(((ShotType)shotSelected).ToString(), shotsAmount[shotSelected].ToString());

    }
    private void ChangeShotType()
    {
        shotSelected = (shotSelected < shotsAmount.Count - 1) ? (shotSelected += 1) : 0;
        GunsFeedback.OnGunEvent?.Invoke(((ShotType)shotSelected).ToString(), shotsAmount[shotSelected].ToString());
    }
}
