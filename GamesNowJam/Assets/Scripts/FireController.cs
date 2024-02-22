using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject poop;
    public GameObject firePoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    private void Fire()
    {
        Instantiate(poop, firePoint.transform.position, firePoint.transform.rotation);
    }
}
