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
        healthBar.SetHealth(health);
    }
    public void PlayerInput()
    {
        bool hasInput = false, mouseLeftClick = false;
        inputManager.PcCheckInputs(ref hasInput, ref mouseLeftClick);
        Vector3 movementInp = inputManager.PcKeyInputs(0);
        if (hasInput)
        {
            playerShipcontroller.ShipMovement(movementInp, shipRb, mvtSpeed);
        }
        else
            shipRb.velocity = Vector3.zero;

        if (mouseLeftClick)
            Shoot();

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
