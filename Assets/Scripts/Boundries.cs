using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void LateUpdate()
    {
        Vector3 ClampPos = transform.position;
        ClampPos.x = Mathf.Clamp(ClampPos.x, screenBounds.x, screenBounds.x * -1);
        ClampPos.y = Mathf.Clamp(ClampPos.y, screenBounds.y, screenBounds.y * -1);
        transform.position = ClampPos;

    }
}
