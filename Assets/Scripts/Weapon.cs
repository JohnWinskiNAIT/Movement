using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Weapon Variables
    int ammoCount, poolCount, index;
    float fireRate, velocity, timeStamp;

    [SerializeField] GameObject projectile, barrelEnd;
    [SerializeField] GameObject[] grenades;

    // Start is called before the first frame update
    void Start()
    {
        ammoCount = 20;
        poolCount = 5;
        fireRate = 0.5f;
        velocity = 20.0f;

        GameObject instantiatedObject;

        grenades = new GameObject[poolCount];

        for (int i = 0; i < grenades.Length; i++)
        {
            instantiatedObject = Instantiate(projectile);
            instantiatedObject.SetActive(false);
            //instantiatedObject.transform.SetParent(transform);
            grenades[i] = instantiatedObject;
            Physics.IgnoreCollision(GetComponentInChildren<Collider>(), instantiatedObject.GetComponentInChildren<Collider>());
        }
    }

    void Fire()
    {
        if (ammoCount > 0 && Time.time > timeStamp + fireRate)
        {
            timeStamp = Time.time;
            ammoCount--;

            grenades[index].transform.position = barrelEnd.transform.position;
            grenades[index].transform.rotation = barrelEnd.transform.rotation;
            grenades[index].SetActive(true);
            grenades[index].GetComponent<Rigidbody>().velocity = transform.forward * velocity;

            index++;

            if (index >= poolCount)
            {
                index = 0;
            }
        }
    }
}
