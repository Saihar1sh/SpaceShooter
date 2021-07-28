using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipView : MonoBehaviour
{
    public float mvtSpeed, rotatingSpeed;

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
    }

    public void GetPlayerController(PlayerShipcontroller _playerShipcontroller)
    {
        this.playerShipcontroller = _playerShipcontroller;
    }
}
