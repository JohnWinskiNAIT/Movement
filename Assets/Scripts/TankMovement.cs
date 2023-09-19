using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    public InputAction moveAction;
    Vector2 moveValue;

    [SerializeField] float movementSpeed, rotationSpeed, movementForce, rotationForce;

    Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rbody.AddRelativeForce(Vector3.forward * movementForce * Time.fixedDeltaTime * (moveValue.x + moveValue.y), ForceMode.Acceleration);

        rbody.AddRelativeTorque(Vector3.up * rotationForce * Time.fixedDeltaTime * (moveValue.y - moveValue.x), ForceMode.Acceleration);

        //transform.Translate(Vector3.forward * movementSpeed * Time.fixedDeltaTime * (moveValue.x + moveValue.y));
        //transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime * (moveValue.y - moveValue.x));
    }
    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }
}
