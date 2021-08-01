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

    public void SpawnBullet(Transform[] _firePoints, float _delay)
    {
        if (canShoot)
            StartCoroutine(ShootDelay(_firePoints, _delay));
    }

    public void SpawnEnemyBullet(Vector3 _shipPos, float _delay)
    {
        if (canEShoot)
            StartCoroutine(ShootEnemyDelay(_shipPos, _delay));
    }


    IEnumerator ShootDelay(Transform[] firePoints, float delay)
    {
        canShoot = false;
        for (int i = 0; i < firePoints.Length; i++)
        {

            Instantiate(blueBulletPrefab, firePoints[i].position, firePoints[i].rotation);
            Debug.Log(firePoints[i].position, firePoints[i]);
        }
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
    IEnumerator ShootEnemyDelay(Vector3 shipPosition, float delay)
    {
        canEShoot = false;
        shipPosition.x -= 3f;
        Instantiate(redBulletPrefab, shipPosition, Quaternion.Euler(0, 180, 0));
        yield return new WaitForSeconds(delay);
        canEShoot = true;
    }

}
