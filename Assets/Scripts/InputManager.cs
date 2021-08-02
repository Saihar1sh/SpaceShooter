using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingletonGeneric<InputManager>
{
    private Joystick joystick;
    private bool shootBtnClick;

    public void PcCheckInputs(ref bool _hasInput)
    {
        _hasInput = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
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


    public void TouchInputsCheck(ref bool _hasInput)
    {
        _hasInput = joystick.Direction.x != 0 && joystick.Direction.y != 0;
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
