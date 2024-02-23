using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PoopBar : MonoBehaviour
{
    [SerializeField] Slider poop;
    [SerializeField] float poopAmount = 30;
    // Start is called before the first frame update
    private void Start()
    {
        UpdatePoopBar(0.0f);
    }
    public void UpdatePoopBar(float UpdateValue)
    {
        poopAmount += UpdateValue;
        poop.value = poopAmount / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
