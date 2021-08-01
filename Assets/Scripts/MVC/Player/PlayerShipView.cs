using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShipView : MonoBehaviour
{
    [Header("Variables")]
    public int maxHealth = 100;
    public float mvtSpeed, rotatingSpeed;


    private int health;

    [SerializeField]
    private Transform[] firePoints;

    private Rigidbody shipRb;

    private PlayerShipcontroller playerShipcontroller;

    [SerializeField]
    private HealthBar healthBar;

    private InputManager inputManager;

    private void Awake()
    {
        shipRb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        health = maxHealth;
        playerShipcontroller = new PlayerShipcontroller(this);
        inputManager = InputManager.Instance;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        PlayerInput();
        HealthCheck();
    }

    private void HealthCheck()
    {
        healthBar.SetHealth(health);
        if (health <= 0)
            health = 0;

        if (health == 0)
        {
            ParticleService.Instance.CommenceExplosion(transform);
            Destroy(gameObject);
        }
    }

    public void PlayerInput()
    {
#if UNITY_STANDALONE || UNITY_EDITOR    //if the current platform is not mobile, setting mouse handling 

        bool hasInput = false, mouseLeftClicked = false;
        inputManager.PcCheckInputs(ref hasInput, ref mouseLeftClicked);
        Vector3 movementInp = inputManager.PcKeyInputs(0);
        if (hasInput)
        {
            playerShipcontroller.ShipMovement(movementInp, shipRb, mvtSpeed);
        }
        else
            shipRb.velocity = Vector3.zero;

        if (mouseLeftClicked)
            Shoot();

#endif
#if UNITY_IOS || UNITY_ANDROID //if current platform is mobile, 


        Vector3 _movementInput = inputManager.TouchInputs(0);


#endif
    }

    private void Shoot()
    {
        BulletService.Instance.SpawnBullet(firePoints, 1f);
    }

    public void ModifyHealth(int value)
    {
        health += value;
    }

    public void GetPlayerController(PlayerShipcontroller _playerShipcontroller)
    {
        this.playerShipcontroller = _playerShipcontroller;
    }
}
