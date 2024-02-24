using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float lifetime = 5f;
    // Start is called before the first frame update

    public void Set()
    {
        GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }
    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0f)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
