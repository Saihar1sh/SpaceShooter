using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    [SerializeField]
    private BulletController blueBulletPrefab, redBulletPrefab;

    private bool canShoot = true, canEShoot = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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


    /*    IEnumerator ShootDelay(Transform[] firePoints, float delay)
        {
            canShoot = false;
            for (int i = 0; i < firePoints.Length; i++)
            {
                Instantiate(blueBulletPrefab, firePoints[i].position, firePoints[i].rotation);

            }
            yield return new WaitForSeconds(delay);
            canShoot = true;
        }
        IEnumerator ShootEnemyDelay(Vector3 firePosition, float delay)
        {
            canEShoot = false;
            BulletController bullet = Instantiate(redBulletPrefab, firePosition, Quaternion.Euler(0, 180, 0));
            yield return new WaitForSeconds(delay);
            canEShoot = true;
        }
    */
}
