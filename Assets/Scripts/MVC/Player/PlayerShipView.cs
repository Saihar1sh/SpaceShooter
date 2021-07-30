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

    private void Awake()
    {
        shipRb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        playerShipcontroller = new PlayerShipcontroller(this);
    }

    void Update()
    {
        PlayerInput();
    }
    public void PlayerInput()
    {
        float keyBoardHorizontal = Input.GetAxis("Horizontal");
        float keyBoardVertical = Input.GetAxis("Vertical");
        if (keyBoardHorizontal != 0 || keyBoardVertical != 0)
        {
            Vector3 movementInput = new Vector3(keyBoardHorizontal, keyBoardVertical, 0);
            playerShipcontroller.ShipMovement(movementInput, shipRb, mvtSpeed);


        }

        if (Input.GetMouseButton(0))
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
