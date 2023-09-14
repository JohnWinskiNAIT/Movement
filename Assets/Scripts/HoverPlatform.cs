using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPlatform : MonoBehaviour
{
    Rigidbody rbody;
    [SerializeField] float distance, antigravForce;
    RaycastHit hit;
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        antigravForce = rbody.mass;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            rbody.AddForce(transform.up * (distance - hit.distance) / distance * antigravForce, ForceMode.Impulse);
        }
    }
}
