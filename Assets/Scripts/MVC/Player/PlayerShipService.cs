using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipService : MonoSingletonGeneric<PlayerShipService>
{
    public PlayerShipModel shipModel;
    public PlayerShipcontroller shipcontroller;
    public PlayerShipView playerShipView;

    [SerializeField]
    private Vector3 spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerShip();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public PlayerShipcontroller CreatePlayerShip()
    {
        PlayerShipcontroller playerShipcontroller = new PlayerShipcontroller(playerShipView, shipModel, spawnpoint, Quaternion.Euler(-90, 90, 0));
        return playerShipcontroller;
    }
}
