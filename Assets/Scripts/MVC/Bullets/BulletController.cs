using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 2f, maxLifetime = 4f;

    [SerializeField]
    private int damage = 10;

    public LazerTypes lazerTypes;

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

        switch (lazerTypes)
        {
            case LazerTypes.None:
                break;
            case LazerTypes.Blue:
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

                break;
            case LazerTypes.Red:
                if (other.gameObject.tag == "Player")
                {
                    other.GetComponent<PlayerShipView>().ModifyHealth(-damage);
                }

                break;
            default:
                break;
        }

    }
}
public enum LazerTypes
{
    None,
    Red,
    Blue,
}