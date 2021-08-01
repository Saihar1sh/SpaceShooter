using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingletonGeneric<InputManager>
{
    private Joystick joystick;

    void Update()
    {

    }

    public void PcCheckInputs(ref bool _hasInput, ref bool _mouseLeftClick)
    {
        _hasInput = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        _mouseLeftClick = Input.GetMouseButton(0);

    }

    public Vector3 PcKeyInputs(float zPos)
    {
        Vector3 inputMvt = Vector3.zero;
        inputMvt.x = Input.GetAxis("Horizontal");
        inputMvt.y = Input.GetAxis("Vertical");
        inputMvt.z = zPos;
        return inputMvt;
    }

    public void SetJoystick(Joystick _joystick)
    {
        joystick = _joystick;
    }

    public Vector3 TouchInputs(float zPos)
    {

        Vector3 touchMvt = Vector3.zero;
        touchMvt.x = joystick.Horizontal;
        touchMvt.y = joystick.Vertical;
        touchMvt.z = zPos;
        return touchMvt;
    }
}
