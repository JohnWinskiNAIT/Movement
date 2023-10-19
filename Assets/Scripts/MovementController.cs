using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    // Input variables
    public InputAction moveAction, rotateAction, fireAction;

    [SerializeField] Vector2 moveValue, rotateValue;

    // Movement variables
    float movementSpeed, rotationSpeed;

    [SerializeField] GameObject weapon, cam, target;

    RaycastHit hit;

    // Clamping variables
    Vector3 angles;

    // Get the audiosource
    AudioSource mySource;

    // Get the animator for the player
    [SerializeField] Animator myAnimator;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize movement variable;
        movementSpeed = 3.0f;
        rotationSpeed = 500.0f;

        mySource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        {
            target.transform.position = hit.point;
        }

        if (fireAction.WasPressedThisFrame())
        {
            BroadcastMessage("Fire");
        }
    }

    void MovePlayer()
    {
        // Get player input
        moveValue = moveAction.ReadValue<Vector2>();
        rotateValue = rotateAction.ReadValue<Vector2>();
        
        // Rotate player
        transform.Rotate(Vector3.up, rotateValue.x * rotationSpeed * Time.deltaTime);
        //Rotate weapon
        weapon.transform.Rotate(Vector3.right, rotateValue.y * rotationSpeed * Time.deltaTime);

        // Get the current weapon angles
        angles = weapon.transform.eulerAngles;

        // Check the angles to see if they need to be clamped
        if (angles.x > 45.0f && angles.x < 180.0f)
        {
            weapon.transform.localRotation = Quaternion.Euler(45.0f, 0, 0);
        }
        if (angles.x < 270.0f && angles.x > 180.0f)
        {
            weapon.transform.localRotation = Quaternion.Euler(270.0f, 0, 0);
        }

        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.VelocityChange);
            }
        }

        if (moveValue.magnitude > 0)
        {
            if (!mySource.isPlaying)
            {
                mySource.Play();
                myAnimator.SetBool("Walking", true);
            }
        }
        else
        {
            mySource.Stop();
            myAnimator.SetBool("Walking", false);
        }
    }

    private void FixedUpdate()
    {
        // Move the object
        transform.Translate(new Vector3(moveValue.x, 0, moveValue.y) * movementSpeed * Time.deltaTime);
}

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
        fireAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        fireAction.Disable();
    }
}
