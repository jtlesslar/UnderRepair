using System;
using UnityEngine;

public class OURInteract : Interactable
{

    bool hasMaterial = false;

    bool repaired = false;

    float nextRepairTime = 0f;
    float repairDelay = 0.5f;

    ProgressBar progressBar;

    AudioSource audioSource;

    GameObject player;

    GameObject winScreen;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        progressBar = GetComponentInChildren<ProgressBar>();

        winScreen = GameObject.Find("Win Screen");

        winScreen.SetActive(false);
    }

    public override void Interact(GameObject player)
    {
        base.Interact(player);

        this.player = player;

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
                    progressBar.BarValue += 20;

                    audioSource.Play();
                    
                    nextRepairTime = Time.time + repairDelay;
                }
                else
                {
                    winScreen.SetActive(true);

                    TMPro.TextMeshProUGUI text= winScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>();

                    text.text = player.name + "wins!";

                    Time.timeScale = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider material)
    {
        Debug.Log(material.name);
        if (material.tag == "Material")
        {
            Debug.Log(material.tag);
            hasMaterial = true;
            Destroy(material.gameObject);
        }
    }
}

