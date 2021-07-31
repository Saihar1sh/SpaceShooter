using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingletonGeneric<InputManager>
{
    public Vector3 vector;

    private int p = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

        }

    }

    public void PcCheckInputs(ref bool _hasInput, ref bool _mouseLeftClick)
    {
        _hasInput = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        _mouseLeftClick = Input.GetMouseButton(0);

    }

    public Vector3 PcKeyInputs(float zPos)
    {
        Vector3 inputMvt;
        inputMvt.x = Input.GetAxis("Horizontal");
        inputMvt.y = Input.GetAxis("Vertical");
        inputMvt.z = zPos;
        return inputMvt;
    }
}
