using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 2f, maxLifetime = 5f;

    [SerializeField]
    private int damage = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, maxLifetime);
    }

    void Update()
    {
        rb.velocity = transform.right * speed;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.GetComponent<EnemyView>() != null)
            {
                other.GetComponent<EnemyView>().ModifyHealth(-damage);
            }

            if (other.GetComponent<AsteroidMovement>() != null)
            {
                other.GetComponent<AsteroidMovement>().ExplodeAsteriod();
            }
        }

    }
}
