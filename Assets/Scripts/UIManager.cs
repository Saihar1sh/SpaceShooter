using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingletonGeneric<UIManager>
{
    private TextMeshProUGUI scoreTxt;

    private Joystick floatingJoystick, fixedJoystick;

    private bool floJoy = false, fixJoy = false;                                //if floating joystick is present, if fixed joystick is present respectively.

    protected override void Awake()
    {
        base.Awake();
        if (FindObjectOfType<FloatingJoystick>() != null)
        {
            floatingJoystick = FindObjectOfType<FloatingJoystick>();
            floJoy = true;
        }
        if (FindObjectOfType<FixedJoystick>() != null)
        {
            fixedJoystick = FindObjectOfType<FixedJoystick>();
            fixJoy = true;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.SetJoystick(floatingJoystick);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
