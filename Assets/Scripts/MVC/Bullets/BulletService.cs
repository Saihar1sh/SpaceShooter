using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    [SerializeField]
    private BulletController bulletPrefab;

    private bool canShoot = true;

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

    IEnumerator ShootDelay(Transform[] firePoints, float delay)
    {
        canShoot = false;
        for (int i = 0; i < firePoints.Length; i++)
        {
            Instantiate(bulletPrefab, firePoints[i].position, firePoints[i].rotation);
        }
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
