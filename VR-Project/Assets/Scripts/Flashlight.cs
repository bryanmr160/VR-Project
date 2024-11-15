using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : GrabbableEvents
{
    Grabbable flashlight;
    public GameObject lightBulb;
    bool lightFunction = false;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponent<Grabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        //controls light
        //add inputs from vr controller
        if (flashlight.BeingHeld && input.BButtonDown)
        {
            lightFunction = !lightFunction;
        }

        if (flashlight.BeingHeld)
        {
            print("held");
        }

        if (lightFunction)
        {
           print("pressed button");
           lightBulb.SetActive(true);
        }
        else
        {
            lightBulb.SetActive(false);
        }
    }
}
