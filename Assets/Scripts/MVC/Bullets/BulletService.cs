using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    [SerializeField]
    private BulletController blueBulletPrefab, redBulletPrefab;

    private bool canShoot = true, canEShoot = true;

    public void SpawnBullet(Transform[] firePoints)
    {
        if (canShoot)
        {
            for (int i = 0; i < firePoints.Length; i++)
            {
                BulletController bulletController = Instantiate(blueBulletPrefab, firePoints[i].position, firePoints[i].rotation);
                bulletController.lazerTypes = LazerTypes.Blue;
            }
        }
    }

    public void SpawnEnemyBullet(Transform[] firePos)
    {
        if (canEShoot)
        {
            for (int i = 0; i < firePos.Length; i++)
            {
                BulletController bulletController = Instantiate(redBulletPrefab, firePos[i].position, Quaternion.Euler(0, 180, 0));
                bulletController.lazerTypes = LazerTypes.Red;
            }
        }

    }


}
