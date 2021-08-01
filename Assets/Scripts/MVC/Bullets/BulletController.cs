using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private Rigidbody rb;

    public bool flipBullet = false;

    private int flipVar = 1;

    [SerializeField]
    private float speed = 2f, maxLifetime = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, maxLifetime);
    }

    // Start is called before the first frame update
    void Start()
    {
        //flipVar = flipBullet ? -1 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed * flipVar;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("ujd");
        }

    }
}
