using System;
using UnityEngine;

public class OURInteract : Interactable
{

    bool hasMaterial = true;

    bool repaired = false;

    float nextRepairTime = 0f;
    float repairDelay = 0.5f;

    ProgressBar progressBar;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        progressBar = GetComponentInChildren<ProgressBar>();
    }

    public override void Interact()
    {
        base.Interact();

        Repair();
    }
    
    void Repair()
    {
        if (nextRepairTime < Time.time)
        {
            Debug.Log("Repairing OUR");

            if (hasMaterial && !repaired)
            {
                if (progressBar.BarValue < 100)
                {
                    progressBar.BarValue += 10;

                    audioSource.Play();
                    
                    nextRepairTime = Time.time + repairDelay;
                }
            }
        }
    }
}

