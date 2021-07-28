using UnityEngine;
public class PlayerShipcontroller
{
    public PlayerShipcontroller(PlayerShipView playerShipView)
    {
        playerShipView.GetPlayerController(this);
    }

    public PlayerShipcontroller(PlayerShipView playerShipPrefab, PlayerShipModel playerShipModel, Vector3 pos, Quaternion quaternion)
    {
        PlayerShipView = GameObject.Instantiate<PlayerShipView>(playerShipPrefab, pos, quaternion);
    }

    public void ShipMovement(Vector3 movementInput, Rigidbody shipRb, float mvtSpeed)
    {
        //Debug.Log("horizontal: " + horizontal + " vertical:" + vertical);
        shipRb.MovePosition(shipRb.position + movementInput * mvtSpeed * Time.deltaTime);
        //Vector3 rotation = movementInput * rotatingSpeed;
        //shipRb.transform.rotation = Quaternion.LookRotation(rotation);
    }



    public PlayerShipView PlayerShipView { get; }

}
