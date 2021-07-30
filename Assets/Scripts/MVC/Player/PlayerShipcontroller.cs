using UnityEngine;
public class PlayerShipcontroller
{
    public PlayerShipcontroller(PlayerShipView playerShipView)
    {
        playerShipView.GetPlayerController(this);
        this.PlayerShipView = playerShipView;
    }

    public PlayerShipcontroller(PlayerShipView playerShipPrefab, PlayerShipModel playerShipModel, Vector3 pos, Quaternion quaternion)
    {
        PlayerShipView = GameObject.Instantiate<PlayerShipView>(playerShipPrefab, pos, quaternion);
    }

    public void ShipMovement(Vector3 movementInput, Rigidbody shipRb, float mvtSpeed)
    {
        shipRb.MovePosition(shipRb.position + movementInput * mvtSpeed * Time.deltaTime);
    }


    public PlayerShipView PlayerShipView { get; }

}
