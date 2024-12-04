using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem system;
    Grabbable grabbable;
    bool wasHeld;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<Grabbable>();
    }

    void FixedUpdate()
    {
        if(grabbable.BeingHeld && !wasHeld)
        {
            wasHeld = true;
            system.Stop();
        }
    }
}
