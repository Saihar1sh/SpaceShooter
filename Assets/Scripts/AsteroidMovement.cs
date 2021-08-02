using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        EnemyService.Instance.asteroidsObjs.Add(this);
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        rb.velocity = transform.right * -1 * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerShipView>() != null)
        {
            PlayerShipView playerShip = collision.gameObject.GetComponent<PlayerShipView>();
            playerShip.ModifyHealth(-damage);
        }
    }

    public void ExplodeAsteriod()
    {
        ParticleService.Instance.CommenceExplosion(transform);
        UIManager.Instance.ScoreIncreament(10);
        EnemyService.Instance.asteroidsObjs.Remove(this);
        Destroy(gameObject);
    }
}
