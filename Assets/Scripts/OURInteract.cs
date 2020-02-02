using System;
using UnityEngine;

public class OURInteract : Interactable
{

    bool hasMaterial = false;

    int materialCount = 0;

    bool repaired = false;

    float nextRepairTime = 0f;
    float repairDelay = 0.5f;

    ProgressBar progressBar;

    AudioSource audioSource;

    GameObject player;

    public GameObject winScreen;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        progressBar = GetComponentInChildren<ProgressBar>();

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

                    if (progressBar.BarValue >= 100)
                    {
                        winScreen.SetActive(true);

                        TMPro.TextMeshProUGUI text = winScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>();

                        text.text = player.name + "wins!";

                        Time.timeScale = 0;
                    }
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

            materialCount++;
            if (materialCount >=2)
            {
                hasMaterial = true;
            }
              
            Destroy(material.gameObject);
        }
    }

}

