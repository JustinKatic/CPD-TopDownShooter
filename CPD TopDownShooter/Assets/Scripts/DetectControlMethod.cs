using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectControlMethod : MonoBehaviour
{
    public PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //detect mouse input
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            thePlayer.useMouseController = true;
            thePlayer.usePS4Controller = false;
        }

        if (Input.GetAxisRaw("Mouse X") != 0.0f || Input.GetAxisRaw("Mouse Y") != 0.0f)
        {
            thePlayer.useMouseController = true;
            thePlayer.usePS4Controller = false;
        }



        //detect Controller input
        if (thePlayer.controls.Player.Rotation.ReadValue<Vector2>().x != 0.0f || thePlayer.controls.Player.Rotation.ReadValue<Vector2>().y != 0.0f) 
        { 
            thePlayer.usePS4Controller = true;
            thePlayer.useMouseController = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button0) ||
            Input.GetKey(KeyCode.Joystick1Button1) ||
            Input.GetKey(KeyCode.Joystick1Button2) ||
            Input.GetKey(KeyCode.Joystick1Button3) ||
            Input.GetKey(KeyCode.Joystick1Button4) ||
            Input.GetKey(KeyCode.Joystick1Button5) ||
            Input.GetKey(KeyCode.Joystick1Button6) ||
            Input.GetKey(KeyCode.Joystick1Button7) ||
            Input.GetKey(KeyCode.Joystick1Button8) ||
            Input.GetKey(KeyCode.Joystick1Button9) ||
            Input.GetKey(KeyCode.Joystick1Button10))
        {
            thePlayer.usePS4Controller = true;
            thePlayer.useMouseController = false;
        }
        
           
    }
}
