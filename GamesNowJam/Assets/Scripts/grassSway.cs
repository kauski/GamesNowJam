using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class grassSway : MonoBehaviour
{
    // Start is called before the first frame update
    private Material material;
    public PathFollower pathFollower;
    public GameObject Camera;
    private float multiplier;
    public FloatVariable multiplierValue;
    void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        Camera = GameObject.FindWithTag("MainCameraControl");
        multiplier = multiplierValue.GetValue();

    }

    // Update is called once per frame
    void Update()
    {
        multiplier = multiplierValue.GetValue();
     //   Debug.Log("multiplier;"+multiplier);
        material.SetFloat("WindS", multiplier);
        
        
    }
}
