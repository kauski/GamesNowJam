using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Guardshit : MonoBehaviour
{
    public TMP_Text GuardsLeft;
    [SerializeField] int guardsLeftCounter = 1;
    public GameObject EndScreenWin;
    
    // Start is called before the first frame update
    void Start()
    {
        GuardsLeft.text = "Guards to poop: " + guardsLeftCounter;
    }
    public void UpdateUI()
    {
        guardsLeftCounter -= 1;
        GuardsLeft.text = "Guards to poop: " + guardsLeftCounter;
        if (guardsLeftCounter <= 0)
        {
            
            EndScreenWin.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
