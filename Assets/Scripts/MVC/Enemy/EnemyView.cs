using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public float mvtSpeed = 5f;

    private bool canShoot = true;

    private Rigidbody rb;

    [SerializeField]
    private Transform[] firePoints;

    private EnemyController enemyController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (canShoot)
            StartCoroutine(LazerDelay());
    }

    private void Movement()
    {
        rb.velocity = transform.right * -1 * mvtSpeed;
    }

    public void GetEnemyController(EnemyController _enemyController)
    {
        this.enemyController = _enemyController;
    }


    IEnumerator LazerDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        BulletService.Instance.SpawnBullet(firePoints, 0f);
        canShoot = true;
    }
}
