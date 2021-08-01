using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public float mvtSpeed = 5f;

    public int damage = 10, maxHealth = 100;

    private float health;

    private bool canShoot = true;

    private Rigidbody rb;

    [SerializeField]
    private Transform firePoint;

    private EnemyController enemyController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        health = maxHealth;
        Destroy(gameObject, 15f);                               //max lifetime
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        HealthCheck();
        if (canShoot)
            StartCoroutine(LazerDelay());
    }
    private void HealthCheck()
    {
        if (health <= 0)
            health = 0;

        if (health == 0)
        {
            ParticleService.Instance.CommenceExplosion(transform);
            Destroy(gameObject);
        }
    }
    public void ModifyHealth(int value)
    {
        health += value;
    }

    private void Movement()
    {
        rb.velocity = transform.up * -1 * mvtSpeed;                                 //it moves along green axis which is forward according to prefab

    }
    public void GetEnemyController(EnemyController _enemyController)
    {
        this.enemyController = _enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerShipView>() != null)
        {
            PlayerShipView playerShip = collision.gameObject.GetComponent<PlayerShipView>();
            playerShip.ModifyHealth(-damage);
        }
    }



    IEnumerator LazerDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(10);
        BulletService.Instance.SpawnEnemyBullet(firePoint.position, 1f);
        canShoot = true;
    }
}
