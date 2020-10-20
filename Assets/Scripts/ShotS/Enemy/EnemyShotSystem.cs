using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSystem : ShotSystem
{
    private Transform target;
    private float reloadTime = 1.5f;
    private float shotTime = 0f;

    public EnemyShotSystem(Entity entity, List<GameObject> shotPrefabs, Transform target) : base(entity, shotPrefabs)
    {
        this.target = target;
    }
    public override void CreateShot()
    {
        Vector3 direction = (target.position - entity.transform.position).normalized;
        
        GameObject shotObject = GameObject.Instantiate(prefabs[0], entity.transform.position, Quaternion.identity);
        Shot shot = shotObject.GetComponent<Shot>();
        shot.Setup(direction, 0.05f, entity);

        ResetSystem();
    }

    public override void Tick()
    {
        shotTime += Time.deltaTime;
        if(shotTime > reloadTime)
        {
            CreateShot();
        }
    }
    public override void ResetSystem()
    {
        shotTime = 0;
    }
}
