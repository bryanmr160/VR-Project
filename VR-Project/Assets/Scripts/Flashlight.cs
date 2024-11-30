using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Flashlight : GrabbableEvents
{
    Grabbable flashlight;
    public GameObject lightBulb;
    public float battery = 0;
    bool lightFunction = false;
    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponent<Grabbable>();
        battery = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //controls light
        //add inputs from vr controller
        if (flashlight.BeingHeld && (input.BButtonDown || Input.GetKeyDown(KeyCode.C)) )
        {
            lightFunction = !lightFunction;
        }

        if (flashlight.BeingHeld)
        {
            Debug.Log("Being Held");
        }

        if (lightFunction && battery >= 0)
        {
           print("pressed button");
           lightBulb.SetActive(true);
           battery -= 1 * Time.deltaTime;
            Debug.Log("Battery %" + battery);
        }
        else
        {
            lightBulb.SetActive(false);
        }
    }
}
