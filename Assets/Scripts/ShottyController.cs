using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottyController : BaseTower
{

    public override void Shoot()
    {
        for(int i = 0; i < bulletSpawnPositions.Length; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Instantiate(bullet, bulletSpawnPositions[i].transform.position, transform.rotation*Quaternion.Euler(0,0,(i*5)-15f));

            }
            Instantiate(flash, bulletSpawnPositions[i].transform.position, transform.rotation);

        }
        src.Play();

        cools = shootSpeed;
        base.Shoot();
    }
}
