using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] SpawnManager spawnManagerScript;
    [SerializeField] Guardshit guardshitScript;   
    // Start is called before the first frame update
    private void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        guardshitScript = GameObject.Find("Canvas").GetComponent<Guardshit>();
    }
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
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Guardian")
        {
            other.gameObject.SetActive(false);
            guardshitScript.UpdateUI();
                spawnManagerScript.CounterGuardian();
            
        }
         if (other.gameObject.tag == "Treat"){
            other.gameObject.SetActive(false);
        }
    }
}
