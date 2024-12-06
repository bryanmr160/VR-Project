using BNG;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;

namespace BNG
{
    public class FlashlightFunction : GrabbableEvents
    {
        Grabbable flashlight;
        Battery currentBattery;
        public Light lightBulb;

        public AudioClip ClickSound;
        public float SoundVolume = 1f;

        public TMP_Text batteryPercent;
        public GameObject hud;

        public static bool lightFunction = false;
        // Start is called before the first frame update
        void Start()
        {
            flashlight = GetComponent<Grabbable>();
            lightBulb.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (flashlight.BeingHeld)
            {
                hud.SetActive(true);
                if (currentBattery != null)
                {
                    batteryPercent.text = currentBattery.batteryPercentage.ToString("0") + "%";
                }
            }

            if (!flashlight.BeingHeld)
            {
                hud.SetActive(false);
            }
            //controls light
            //add inputs from vr controller
            if (flashlight.BeingHeld &&  (input.BButtonDown || Input.GetKeyDown(KeyCode.C) ))
            {

                if (currentBattery != null && currentBattery.batteryPercentage > 0f)
                {
                    Debug.Log("flash is on");
                    lightFunction = !lightFunction;
                    lightBulb.enabled = lightFunction;
                }
                
                FlashSound();
            }

            if (lightFunction && currentBattery != null && currentBattery.batteryPercentage <= 0f)
            {
                lightFunction = false;
                lightBulb.enabled = false;
            }

            if (lightFunction && currentBattery != null)
            {
                currentBattery.batteryPercentage -= currentBattery.drainRate * Time.deltaTime;
                currentBattery.batteryPercentage = Mathf.Clamp(currentBattery.batteryPercentage, 0f, 100f);
            }

           



        }

        protected bool playedClickSound = false;

        public virtual void FlashSound()
        {
            VRUtils.Instance.PlaySpatialClipAt(ClickSound, transform.position, SoundVolume, 0.5f);
            playedClickSound = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Battery"))
            {
                Battery newBattery = other.GetComponent<Battery>();
                if (newBattery != null)
                {
                    currentBattery = newBattery;
                    Debug.Log("Battery inserted. Percentage: " + currentBattery.batteryPercentage);
                }
            }

        }
    }
}
