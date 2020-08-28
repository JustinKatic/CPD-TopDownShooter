using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public GunController theGun;
    public GunController theGun1;

    public bool usePS4Controller = false;
    public bool useMouseController = false;

    public Controls controls;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();

        controls = new Controls();
        controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var dirMove = controls.Player.Move.ReadValue<Vector2>();
        //moveVelocity
        moveInput = new Vector3(dirMove.x, 0f, dirMove.y);
        //moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Rotate with Mouse
        if (useMouseController)
        {
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }

            if (Input.GetMouseButtonDown(0))
                theGun.isFireing = true;

            if (Input.GetMouseButtonUp(0))
                theGun.isFireing = false;

            if (Input.GetMouseButtonDown(1))
                theGun1.isFireing = true;

            if (Input.GetMouseButtonUp(1))
                theGun1.isFireing = false;

        }
        //Rotate with Controller
        if (usePS4Controller)
        {
            var dirRot = controls.Player.Rotation.ReadValue<Vector2>();
          //  var playerDirection = controls.Player.Rotation.ReadValue<Vector2>();
           Vector3 playerDirection = Vector3.right * dirRot.x + Vector3.forward * dirRot.y;

            if (playerDirection.sqrMagnitude > 0.0f)
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);

            if (Input.GetKeyDown(KeyCode.JoystickButton7))
                theGun.isFireing = true;

            if (Input.GetKeyUp(KeyCode.JoystickButton7))
                theGun.isFireing = false;

            if (Input.GetKeyDown(KeyCode.JoystickButton6))
                theGun1.isFireing = true;

            if (Input.GetKeyUp(KeyCode.JoystickButton6))
                theGun1.isFireing = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}
