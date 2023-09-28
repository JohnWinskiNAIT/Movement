using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Paintable")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponentInChildren<Renderer>().material.color;
        }
    }
}
