using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSystem : ShotSystem
{
    private Transform target;
    private float reloadTime = 1.5f;
    private float shotTime = 0f;
    private float bulletSpeed;
    private float bulletDamage;

    public EnemyShotSystem(Entity entity, List<GameObject> shotPrefabs, Transform target, float bulletSpeed = 0.01f, float bulletDamage = 5f) : base(entity, shotPrefabs)
    {
        this.target = target;
        this.bulletSpeed = bulletSpeed;
        this.bulletDamage = bulletDamage;
    }
    public override void CreateShot()
    {
        Vector3 direction = (target.position - entity.transform.position).normalized;
        
        GameObject shotObject = GameObject.Instantiate(prefabs[0], entity.transform.position, Quaternion.identity);
        Shot shot = shotObject.GetComponent<Shot>();
        shot.Setup(direction, bulletSpeed, entity, bulletDamage);

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
