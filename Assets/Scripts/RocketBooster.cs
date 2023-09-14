using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBooster : MonoBehaviour
{
    [SerializeField] Rigidbody rbody;
    [SerializeField] float boosterForce;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rbody.AddRelativeForce(Vector3.up *  boosterForce * Time.fixedDeltaTime);
        rbody.AddForceAtPosition(transform.up * boosterForce * Time.fixedDeltaTime, transform.position);
    }
}
