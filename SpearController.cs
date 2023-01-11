using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : WeaponController
{
    public float range;

    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();

        EnemyMove closestEnemy = null;
        float closestEnemyDistance = float.MaxValue;

        foreach (EnemyMove enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemyDistance > range || enemyDistance > closestEnemyDistance)
            {
                continue;
            }

            closestEnemy = enemy;
            closestEnemyDistance = enemyDistance;
        }

        if (closestEnemy == null)
        {
            return;
        }

        GameObject spawnedSpear = Instantiate(weaponData.Prefab, transform.position, Quaternion.identity);
        spawnedSpear.transform.position = transform.position; // Assign the position to be the same as this object which is parented to the player
        spawnedSpear.GetComponent<SpearBehaviour>().Initialize(closestEnemy.transform); // Reference and set direction
    }
}
