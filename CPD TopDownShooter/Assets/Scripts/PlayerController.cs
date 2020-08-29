using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GunController theGun;

    public bool usePS4Controller = false;
    public bool useMouseController = false;

    public Controls controls;

    private Camera cam;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();

        //Get input contols and enable them
        controls = new Controls();
        controls.Enable();
    }

    void Update()
    {
        var dirMove = controls.Player.Move.ReadValue<Vector2>();
        moveInput = new Vector3(dirMove.x, 0f, dirMove.y);
        //store direction and speed inside of move velocity. move velocity applied in FixedUpdate()
        moveVelocity = moveInput * moveSpeed;

        //Rotate with Mouse
        if (useMouseController)
        {
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            float rayLength;
            //if raycast is hitting Plane give raylength variable
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            //If left mouse button down shoot
            if (Input.GetMouseButtonDown(0))
                theGun.isFireing = true;
            //if left mouse button is up dont shoot
            if (Input.GetMouseButtonUp(0))
                theGun.isFireing = false;
        }
        //Rotate with Controller
        if (usePS4Controller)
        {
            //Get the current rotation from input and stores in a vector 3
            var dirRot = controls.Player.Rotation.ReadValue<Vector2>();
           Vector3 playerDirection = Vector3.right * dirRot.x + Vector3.forward * dirRot.y;

            //returns 1 if any rotation is being inputed from right joystick
            if (playerDirection.sqrMagnitude > 0.0f)
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);

            //If player has any rotation slected with right joystick shoot
            if (playerDirection.sqrMagnitude > 0.0f)
                theGun.isFireing = true;

            //If player has no current rotation selected with right joystick dont shoot
            if (playerDirection.sqrMagnitude == 0.0f)
                theGun.isFireing = false;

        }
    }


    private void FixedUpdate()
    {
        //add velocity to player
        rb.velocity = moveVelocity;
    }

}
