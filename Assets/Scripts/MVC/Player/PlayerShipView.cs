using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShipView : MonoBehaviour
{
    public float mvtSpeed, rotatingSpeed;

    [SerializeField]
    private Transform firePoint;

    private Rigidbody shipRb;

    private PlayerShipcontroller playerShipcontroller;

    private InputManager inputManager;

    private void Awake()
    {
        shipRb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        playerShipcontroller = new PlayerShipcontroller(this);
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        PlayerInput();
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

        if (mouseLeftClick)
            Shoot();

    }

    private void Shoot()
    {
        BulletService.Instance.SpawnBullet(firePoint, 1f);
    }

    public void GetPlayerController(PlayerShipcontroller _playerShipcontroller)
    {
        this.playerShipcontroller = _playerShipcontroller;
    }
}
