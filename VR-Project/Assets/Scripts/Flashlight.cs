using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //controls light
        //add inputs from vr controller
        if (light != null)
        {
            light.SetActive(true);
        }
    }
}
