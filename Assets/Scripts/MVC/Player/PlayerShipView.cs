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
    private bool canShoot = true;

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
        PlayerShipService.Instance.playerShips.Add(this);
        health = maxHealth;
        inputManager = InputManager.Instance;
        playerShipcontroller = new PlayerShipcontroller(this);
        UIManager.Instance.Start();
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        PlayerInput();
        HealthCheck();

        if (canShoot)
            StartCoroutine(ShootDelay(1));

    }

    private void HealthCheck()
    {
        healthBar.SetHealth(health);
        if (health <= 0)
            health = 0;

        if (health == 0)
        {
            ParticleService.Instance.CommenceExplosion(transform);
            PlayerShipService.playerIsDead = true;
            UIManager.Instance.GameoverUI(true);
            Destroy(gameObject);
        }
    }

    public void PlayerInput()
    {
        //Pc inputs
        bool hasKeyBInput = false;
        inputManager.PcCheckInputs(ref hasKeyBInput);
        Vector3 movementInp = inputManager.PcKeyInputs(0);
        if (hasKeyBInput)
        {
            playerShipcontroller.ShipMovement(movementInp, shipRb, mvtSpeed);
        }
        else
            shipRb.velocity = Vector3.zero;

        //touch Inputs
        bool _hasInput = false;
        inputManager.TouchInputsCheck(ref _hasInput);
        Vector3 _movementInput = inputManager.TouchInputs(0);
        if (_hasInput)
            playerShipcontroller.ShipMovement(_movementInput, shipRb, mvtSpeed);
        else
            shipRb.velocity = Vector3.zero;


    }

    public void ModifyHealth(int value)
    {
        health += value;
    }

    public void GetPlayerController(PlayerShipcontroller _playerShipcontroller)
    {
        this.playerShipcontroller = _playerShipcontroller;
    }

    IEnumerator ShootDelay(float secs)
    {
        canShoot = false;
        yield return new WaitForSeconds(secs);
        BulletService.Instance.SpawnBullet(firePoints);
        canShoot = true;
    }

}
