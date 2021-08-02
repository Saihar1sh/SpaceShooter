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

    public void SpawnBullet(Transform _firePoint, float _delay)
    {
        if (canShoot)
            StartCoroutine(ShootDelay(_firePoint, _delay));
    }

    IEnumerator ShootDelay(Transform firePoint, float delay)
    {
        canShoot = false;
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
