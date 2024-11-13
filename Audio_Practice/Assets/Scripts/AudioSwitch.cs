using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSwitch : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixerSnapshot NormalSnapshot;
    public AudioMixerSnapshot UnderwaterSnapshotSnapshot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ApplyAudioSnapshot(NormalSnapshot, 1.5f);


        }
    }
}
