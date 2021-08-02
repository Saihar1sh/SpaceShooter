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

    public static bool playerIsDead = false;

    public List<PlayerShipView> playerShips;

    // Start is called before the first frame update
    void Start()
    {

        //CreatePlayerShip();
    }
    private void OnEnable()
    {
        playerIsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public PlayerShipcontroller CreatePlayerShip()
    {
        PlayerShipcontroller playerShipcontroller = new PlayerShipcontroller(playerShipView, shipModel, spawnpoint, Quaternion.Euler(0, 90, 0));
        return playerShipcontroller;
    }

}
