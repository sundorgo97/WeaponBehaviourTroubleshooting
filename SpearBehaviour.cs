using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : ProjectileWeaponBehaviour
{

    private Transform target;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += target.position * weaponData.Speed * Time.deltaTime;
        // Something about this doesnt work
        // Perhaps it's the targetting, perhaps the transformation?
    }

    public void Initialize(Transform target)
    {
        this.target = target;
    }

}
