using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    int damage = 5;
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.tag == "Paintable")
        //{
        //    collision.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponentInChildren<Renderer>().material.color;
        //}
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null )
        {
            health.ApplyDamage(damage);
        }

        gameObject.SetActive(false);
    }
}
