using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public GameObject poop;
    public GameObject firePoint;
    public PoopBar poopBarScript;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && poopBarScript.poopAmount > 5.0f)
        {
            poopBarScript.UpdatePoopBar(-5.0f);
            Fire();
        }
    }
    private void Fire()
    {
        Instantiate(poop, firePoint.transform.position, firePoint.transform.rotation);
    }
}
