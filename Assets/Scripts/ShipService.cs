using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipService : MonoSingletonGeneric<ShipService>
{
    public PlayerShipModel shipModel;
    public PlayerShipcontroller shipcontroller;
    public PlayerShipView playerShipView;
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
        Vector3 randomSpawnPos = Vector3.zero; //new Vector3(UnityEngine.Random.Range(-42, 43), 0, UnityEngine.Random.Range(39, -43));
        PlayerShipcontroller playerShipcontroller = new PlayerShipcontroller(playerShipView, shipModel, randomSpawnPos, Quaternion.Euler(0, 90, 0));
        return playerShipcontroller;
    }
}
