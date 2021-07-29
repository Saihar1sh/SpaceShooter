using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private Rigidbody rb;

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
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sjhg");
    }
}
